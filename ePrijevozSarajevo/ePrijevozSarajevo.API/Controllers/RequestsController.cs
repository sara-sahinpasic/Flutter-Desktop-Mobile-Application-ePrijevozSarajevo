using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        protected IRequestsService _service;

        public RequestsController(IRequestsService service)
        {
            this._service = service;
        }
        [HttpGet]
        public List<Request> GetRequests()
        {
            return _service.GetList();
        }
    }
}
