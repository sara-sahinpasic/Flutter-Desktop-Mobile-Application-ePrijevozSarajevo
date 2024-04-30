using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services.TicketsStateMachine
{
    public class ActiveTicketState : BaseTicketState
    {
        public ActiveTicketState(DataContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }
        public override Model.Ticket Hide(int id)
        {
            var set = Context.Set<Database.Ticket>();
            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            Context.SaveChanges();
            return Mapper.Map<Model.Ticket>(entity);
        }
        public override List<string> AllowedActions(Ticket entity)
        {
            return new List<string>() { nameof(Hide) };
        }
    }
}
