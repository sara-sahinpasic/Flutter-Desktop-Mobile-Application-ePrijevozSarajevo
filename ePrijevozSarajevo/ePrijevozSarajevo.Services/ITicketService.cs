using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface ITicketService : ICRUDService<Model.Ticket, TicketSearchObject, TicketInsertRequest, TicketUpdateRequest>
    {
        public Task<Ticket> Activate(int id);
        public Task<Ticket> Edit(int id);
        public Task<Ticket> Hide(int id);
        public Task<List<string>> AllowedActions(int id);
    }
}
