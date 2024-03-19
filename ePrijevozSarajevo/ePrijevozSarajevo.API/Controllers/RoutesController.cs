using ePrijevozSarajevo.Model;
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
            return _service.GetRoutesList();
        }
    }
}
