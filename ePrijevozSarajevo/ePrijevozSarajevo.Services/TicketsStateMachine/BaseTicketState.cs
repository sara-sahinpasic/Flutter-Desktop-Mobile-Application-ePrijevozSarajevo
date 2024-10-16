using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ePrijevozSarajevo.Services.TicketsStateMachine
{
    public class BaseTicketState
    {
        public DataContext _dataContext { get; set; }
        public IMapper _mapper { get; set; }
        public IServiceProvider _serviceProvider { get; set; }
        public BaseTicketState(DataContext context, IMapper mapper, IServiceProvider serviceProvider)
        {
            _dataContext = context;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public async virtual Task <Model.Ticket> Insert(TicketInsertRequest request)
        {
            throw new Exception("Method not allowed");
        }
        public async virtual Task <Model.Ticket> Update(int id, TicketUpdateRequest request)
        {
            throw new UserException("Method not allowed");
        }
        public async virtual Task <Model.Ticket> Activate(int id)
        {
            throw new UserException("Method not allowed");
        }
        public async virtual Task <Model.Ticket> Hide(int id)
        {
            throw new UserException("Method not allowed");
        }
        public async virtual Task <Model.Ticket> Edit(int id)
        {
            throw new UserException("Method not allowed");
        }
        public virtual List<string> AllowedActions(Database.Ticket entity)
        {
            throw new UserException("Method not allowed");
        }

        public async Task <BaseTicketState> CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return _serviceProvider.GetService<InitialTicketState>();
                case "draft":
                    return _serviceProvider.GetService<DraftTicketState>();
                case "active":
                    return _serviceProvider.GetService<ActiveTicketState>();
                case "hidden":
                    return _serviceProvider.GetService<HiddenTicketState>();
                default: throw new Exception("State not recognized");
            }
        }

    }
}
