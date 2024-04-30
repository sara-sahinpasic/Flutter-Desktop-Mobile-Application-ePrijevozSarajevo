using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : BaseCRUDController<Model.Ticket, TicketSearchObject, TicketInsertRequest, TicketUpdateRequest>
    {
        public TicketController(ITicketService service) : base(service)
        {
        }

        //State machine
        [HttpPut("{id}/activate")]
        public Ticket Activate(int id)
        {
            return (_service as ITicketService).Activate(id);
        }
        [HttpPut("{id}/hide")]
        public Ticket Hide(int id)
        {
            return (_service as ITicketService).Hide(id);
        }
        [HttpPut("{id}/edit")]
        public Ticket Edit(int id)
        {
            return (_service as ITicketService).Edit(id);
        }
    }
}
