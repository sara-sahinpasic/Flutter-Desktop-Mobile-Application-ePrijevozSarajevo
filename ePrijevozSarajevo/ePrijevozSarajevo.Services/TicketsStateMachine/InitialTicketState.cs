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
        public override Model.Ticket Insert(TicketInsertRequest request)
        {
            var set = Context.Set<Database.Ticket>();
            var entity = Mapper.Map<Database.Ticket>(request);
            entity.StateMachine = "draft";

            set.Add(entity);
            Context.SaveChanges();

            return Mapper.Map<Model.Ticket>(entity);
        }
    }
}
