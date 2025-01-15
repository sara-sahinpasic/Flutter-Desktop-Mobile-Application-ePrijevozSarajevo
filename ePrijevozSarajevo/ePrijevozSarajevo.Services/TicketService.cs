using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using ePrijevozSarajevo.Services.TicketsStateMachine;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace ePrijevozSarajevo.Services
{
    public class TicketService : BaseCRUDService<Model.Ticket, TicketSearchObject, Database.Ticket, TicketInsertRequest, TicketUpdateRequest>,
        ITicketService
    {
        ILogger<TicketService> _logger;
        public BaseTicketState _ticketState { get; set; }

        public TicketService(DataContext context, IMapper mapper, BaseTicketState ticketState,
            ILogger<TicketService> logger) : base(context, mapper)
        {
            _ticketState = ticketState;
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

        public override async Task<Model.Ticket> Insert(TicketInsertRequest request)
        {

            var uniqueName = _dataContext.Tickets.FirstOrDefault(x => x.Name == request.Name);
            if (uniqueName != null)
            {
                throw new UserException($"Naziv {request.Name} već postoji.");
            }

            Database.Ticket entity = _mapper.Map<Database.Ticket>(request);

            await _dataContext.Tickets.AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Model.Ticket>(entity);
        }

        //
        public override async Task<Model.Ticket> Update(int id, TicketUpdateRequest request)
        {
            var entity = await _dataContext.Tickets.FindAsync(id);

            var state = await _ticketState.CreateState(entity.StateMachine);

            var existingName = _dataContext.Tickets.FirstOrDefault(x => x.Name == request.Name);
            if (existingName != null)
            {
                throw new UserException($"Naziv {request.Name} već postoji.");
            }

            _mapper.Map(request, entity);

            await _dataContext.SaveChangesAsync();

            await state.Update(id, request);

            return _mapper.Map<Model.Ticket>(entity);
        }


        //StateMachine
        public async Task<Model.Ticket> Activate(int id)
        {
            var entity = await GetById(id);
            var state = await _ticketState.CreateState(entity.StateMachine);
            return await state.Activate(id);
        }

        public async Task<Model.Ticket> Edit(int id)
        {
            var entity = await GetById(id);
            var state = await _ticketState.CreateState(entity.StateMachine);
            return await state.Edit(id);
        }

        public async Task<Model.Ticket> Hide(int id)
        {
            var entity = await GetById(id);
            var state = await _ticketState.CreateState(entity.StateMachine);
            return await state.Hide(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            _logger.LogInformation($"Allowed actions for: {id}");


            if (id <= 0)
            {
                var state = await _ticketState.CreateState("initial");
                return state.AllowedActions(null);
            }
            else
            {
                var entity = await _dataContext.Tickets.FindAsync(id);
                var state = await _ticketState.CreateState(entity.StateMachine);
                return state.AllowedActions(entity);
            }
        }
    }
}
