using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface IIssuedTicketService : ICRUDService<Model.IssuedTicket, IssuedTicketSearchObject, IssuedTicketInsertequest, IssuedTicketUpdateRequest> { }
}
