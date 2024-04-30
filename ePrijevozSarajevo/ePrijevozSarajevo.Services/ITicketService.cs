using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface ITicketService : ICRUDService<Model.Ticket, TicketSearchObject, TicketInsertRequest, TicketUpdateRequest>
    {
        public Ticket Activate(int id);
        public Ticket Edit(int id);
        public Ticket Hide(int id);
        public List<string> AllowedActions(int id);
    }
}
