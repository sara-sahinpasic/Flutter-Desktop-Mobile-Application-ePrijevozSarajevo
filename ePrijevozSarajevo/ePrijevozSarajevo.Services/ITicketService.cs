using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface ITicketService : ICRUDService<Model.Ticket, TicketSearchObject, TicketInsertRequest, TicketUpdateRequest>
    {
    }
}
