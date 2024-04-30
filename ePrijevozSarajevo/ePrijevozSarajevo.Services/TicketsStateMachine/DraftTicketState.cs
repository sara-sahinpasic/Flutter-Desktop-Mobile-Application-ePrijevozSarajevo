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

        public override Model.Ticket Update(int id, TicketUpdateRequest request)
        {
            var set = Context.Set<Database.Ticket>();
            var entity = set.Find(id);

            Mapper.Map(request, entity);

            Context.SaveChanges();
            return Mapper.Map<Model.Ticket>(entity);
        }

        public override Model.Ticket Activate(int id)
        {
            var set = Context.Set<Database.Ticket>();
            var entity = set.Find(id);

            entity.StateMachine = "active";

            Context.SaveChanges();
            return Mapper.Map<Model.Ticket>(entity);
        }
        public override Model.Ticket Hide(int id)
        {
            var set = Context.Set<Database.Ticket>();
            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            Context.SaveChanges();
            return Mapper.Map<Model.Ticket>(entity);
        }
    }
}
