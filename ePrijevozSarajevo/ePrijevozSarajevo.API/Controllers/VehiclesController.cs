using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
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
            return _service.GetList();
        }
        [HttpPost]
        public Vehicle Insert(VehiclesInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut]
        public Vehicle Update(int id, VehiclesUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
