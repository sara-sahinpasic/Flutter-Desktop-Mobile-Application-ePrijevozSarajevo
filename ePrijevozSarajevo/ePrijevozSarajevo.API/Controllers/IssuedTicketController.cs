using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IssuedTicketController : BaseCRUDController<Model.IssuedTicket, IssuedTicketSearchObject, IssuedTicketInsertequest, IssuedTicketUpdateRequest>
    {
        public IssuedTicketController(IIssuedTicketService service) : base(service)
        {
        }
    }
}
