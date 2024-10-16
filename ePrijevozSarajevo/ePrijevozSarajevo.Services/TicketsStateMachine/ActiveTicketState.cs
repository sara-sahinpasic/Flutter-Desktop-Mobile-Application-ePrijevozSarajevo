using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services.TicketsStateMachine
{
    public class ActiveTicketState : BaseTicketState
    {
        public ActiveTicketState(DataContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
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
            return new List<string>() { nameof(Hide) };
        }
    }
}
