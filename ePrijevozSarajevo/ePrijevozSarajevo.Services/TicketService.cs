using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using ePrijevozSarajevo.Services.TicketsStateMachine;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace ePrijevozSarajevo.Services
{
    public class TicketService : BaseCRUDService<Model.Ticket, TicketSearchObject, Database.Ticket, TicketInsertRequest, TicketUpdateRequest>, ITicketService
    {
        ILogger<TicketService> _logger;

        public BaseTicketState TicketState { get; set; }
        public TicketService(DataContext context, IMapper mapper, BaseTicketState ticketState, ILogger<TicketService> logger)
            : base(context, mapper)
        {
            TicketState = ticketState;
            this._logger = logger;
        }


        public override IQueryable<Ticket> AddFilter(TicketSearchObject search, IQueryable<Ticket> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrEmpty(search.NameGTE))
            {
                query = query.Where(x => x.Name.StartsWith(search.NameGTE));
            }

            return query;
        }

        //State machine
        public override Model.Ticket Insert(TicketInsertRequest request)
        {
            var state = TicketState.CreateState("initial");
            return state.Insert(request);
        }
        public override Model.Ticket Update(int id, TicketUpdateRequest request)
        {
            var entity = GetById(id);
            var state = TicketState.CreateState(entity.StateMachine);
            return state.Update(id, request);
        }
        public Model.Ticket Activate(int id)
        {
            var entity = GetById(id);
            var state = TicketState.CreateState(entity.StateMachine);
            return state.Activate(id);
        }

        public Model.Ticket Edit(int id)
        {
            var entity = GetById(id);
            var state = TicketState.CreateState(entity.StateMachine);
            return state.Edit(id);
        }

        public Model.Ticket Hide(int id)
        {
            var entity = GetById(id);
            var state = TicketState.CreateState(entity.StateMachine);
            return state.Hide(id);
        }

        public List<string> AllowedActions(int id)
        {
            _logger.LogInformation($"Allowed actions for: {id}");


            if (id <= 0)
            {
                var state = TicketState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = Context.Tickets.Find(id);
                var state = TicketState.CreateState(entity.StateMachine);
                return state.AllowedActions(entity);
            }
        }
    }
}
