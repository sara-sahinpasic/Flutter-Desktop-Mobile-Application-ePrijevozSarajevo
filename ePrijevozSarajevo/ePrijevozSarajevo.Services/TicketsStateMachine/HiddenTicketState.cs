using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services.TicketsStateMachine
{
    public class HiddenTicketState : BaseTicketState
    {
        public HiddenTicketState(DataContext context, IMapper mapper, IServiceProvider serviceProvider) : base(context, mapper, serviceProvider)
        {
        }
        public override Model.Ticket Edit(int id)
        {
            var set = Context.Set<Database.Ticket>();
            var entity = set.Find(id);

            entity.StateMachine = "draft";

            Context.SaveChanges();
            return Mapper.Map<Model.Ticket>(entity);
        }
    }
}
