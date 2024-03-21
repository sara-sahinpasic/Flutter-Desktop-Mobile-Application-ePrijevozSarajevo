using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
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
        [HttpPost]
        public Request Insert(RequestInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut]
        public Request Update(int id, RequestUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
