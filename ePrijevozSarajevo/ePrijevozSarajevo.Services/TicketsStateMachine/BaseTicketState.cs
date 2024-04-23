using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ePrijevozSarajevo.Services.TicketsStateMachine
{
    public class BaseTicketState
    {
        public DataContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
        public BaseTicketState(DataContext context, IMapper mapper, IServiceProvider serviceProvider)
        {
            Context = context;
            Mapper = mapper;
            ServiceProvider = serviceProvider;
        }

        public virtual Model.Ticket Insert(TicketInsertRequest request)
        {
            throw new Exception("Method not allowed");
        }
        public virtual Model.Ticket Update(int id, TicketUpdateRequest request)
        {
            throw new Exception("Method not allowed");
        }
        public virtual Model.Ticket Activate(int id)
        {
            throw new Exception("Method not allowed");
        }
        public virtual Model.Ticket Hide(int id)
        {
            throw new Exception("Method not allowed");
        }

        public BaseTicketState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialTicketState>();
                case "draft":
                    return ServiceProvider.GetService<DraftTicketState>();
                case "active":
                    return ServiceProvider.GetService<ActiveTicketState>();
                default: throw new Exception("State not recognized");
            }
        }

    }
}
