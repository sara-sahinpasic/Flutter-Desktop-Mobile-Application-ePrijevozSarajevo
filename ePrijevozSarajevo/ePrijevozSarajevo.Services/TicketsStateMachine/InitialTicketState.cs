using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services.TicketsStateMachine
{
    public class InitialTicketState : BaseTicketState
    {
        public InitialTicketState(DataContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }
        public override async Task<Model.Ticket> Insert(TicketInsertRequest request)
        {
            var set = _dataContext.Set<Database.Ticket>();
            var entity = _mapper.Map<Database.Ticket>(request);
            entity.StateMachine = "draft";

            await set.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Ticket>(entity);
        }
        public override List<string> AllowedActions(Ticket entity)
        {
            return new List<string>() { nameof(Insert) };
        }
    }
}
