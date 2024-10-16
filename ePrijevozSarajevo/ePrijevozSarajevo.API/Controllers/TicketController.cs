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
        public  async Task <Ticket> Activate(int id)
        {
            return await (_service as ITicketService).Activate(id);
        }
        [HttpPut("{id}/hide")]
        public async Task <Ticket> Hide(int id)
        {
            return await (_service as ITicketService).Hide(id);
        }
        [HttpPut("{id}/edit")]
        public async Task <Ticket> Edit(int id)
        {
            return await (_service as ITicketService).Edit(id);
        }

        [HttpGet("{id}/allowedActions")]
        public async Task <List<string>> AllowedActions(int id)
        {
            return await (_service as ITicketService).AllowedActions(id);
        }
    }
}
