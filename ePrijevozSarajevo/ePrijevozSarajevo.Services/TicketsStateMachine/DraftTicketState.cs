using EasyNetQ;
using ePrijevozSarajevo.Model.Messages;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services.TicketsStateMachine
{
    public class DraftTicketState : BaseTicketState
    {
        public DraftTicketState(DataContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }

        public override async Task<Model.Ticket> Update(int id, TicketUpdateRequest request)
        {
            var set = _dataContext.Set<Database.Ticket>();
            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            await _dataContext.SaveChangesAsync();
            return _mapper.Map<Model.Ticket>(entity);
        }

        public override async Task<Model.Ticket> Activate(int id)
        {
            var set = _dataContext.Set<Database.Ticket>();
            var entity = await set.FindAsync(id);

            entity.StateMachine = "active";

            await _dataContext.SaveChangesAsync();

            var bus = RabbitHutch.CreateBus("host=localhost");

            var mappedEntity = _mapper.Map<Model.Ticket>(entity);
            TicketsActivated message = new TicketsActivated { Ticket = mappedEntity };
            bus.PubSub.Publish(message);

            return mappedEntity;
        }
        public override async Task<Model.Ticket> Hide(int id)
        {
            var set = _dataContext.Set<Database.Ticket>();
            var entity = await set.FindAsync(id);

            entity.StateMachine = "hidden";

            await _dataContext.SaveChangesAsync();
            return _mapper.Map<Model.Ticket>(entity);
        }
        public override List<string> AllowedActions(Ticket entity)
        {
            return new List<string>() { nameof(Update), nameof(Activate), nameof(Hide) };
        }
    }
}
