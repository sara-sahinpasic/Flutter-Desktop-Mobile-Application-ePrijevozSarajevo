using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services.TicketsStateMachine
{
    public class HiddenTicketState : BaseTicketState
    {
        public HiddenTicketState(DataContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }
        public override async Task <Model.Ticket> Edit(int id)
        {
            var set = _dataContext.Set<Ticket>();
            var entity = await set.FindAsync(id);

            entity.StateMachine = "draft";

            await _dataContext.SaveChangesAsync();
            return _mapper.Map<Model.Ticket>(entity);
        }
        public override List<string> AllowedActions(Ticket entity)
        {
            return new List<string>() { nameof(Edit) };
        }
    }
}
