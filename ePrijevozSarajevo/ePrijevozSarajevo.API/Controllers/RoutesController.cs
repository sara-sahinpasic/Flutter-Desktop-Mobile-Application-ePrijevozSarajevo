using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        protected IRoutesService _service;

        public RoutesController(IRoutesService service)
        {
            this._service = service;
        }

        [HttpGet]
        public List<Model.Route> GetRoutes()
        {
            return _service.GetList();
        }
        [HttpPost]
        public Model.Route Insert(RouteInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut]
        public Model.Route Update(int id, RouteUpdateRequest request)
        {
            return _service.Update(id, request);
        }

    }
}
