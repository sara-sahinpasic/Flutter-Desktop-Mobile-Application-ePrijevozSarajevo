using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouteController : BaseCRUDController<Model.Route, RouteSearchObject, RouteInsertRequest, RouteUpdateRequest>
    {
        public RouteController(IRouteService service) : base(service)
        {
        }
    }
}
