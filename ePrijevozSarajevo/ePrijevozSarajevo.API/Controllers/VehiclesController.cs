using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        protected IVehiclesService _service;

        public VehiclesController(IVehiclesService service)
        {
            this._service = service;
        }
        [HttpGet]
        public List<Vehicle> GetVehicles()
        {
            return _service.GetVehiclesList();
        }
    }
}
