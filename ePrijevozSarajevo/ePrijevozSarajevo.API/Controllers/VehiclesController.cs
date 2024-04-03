using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : /*ControllerBase*/ BaseController<Model.Vehicle, VehicleSearchObject>
    {
        protected IVehiclesService _service;

        public VehiclesController(IVehiclesService service) : base(service) { }
        /* {
             this._service = service;
         }*/

        //Vehicle
        //[HttpGet]
        //public PagedResult<Vehicle> GetVehicles([FromQuery] VehicleSearchObject searchObject)
        //{
        //    return _service.GetList(searchObject);
        //}
        [HttpPost]
        public Vehicle InsertVehicle(VehicleInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut]
        public Vehicle UpdateVehicle(int id, VehicleUpdateRequest request)
        {
            return _service.Update(id, request);
        }

        //VehicleType
        [HttpGet("VehicleTypes")]
        public List<VehicleType> GetVehicleTypes()
        {
            return _service.GetVehicleTypeList();
        }
        [HttpPost("VehicleType")]
        public VehicleType InsertVehicleType(VehicleTypeInsertRequest request)
        {
            return _service.InsertVehicleType(request);
        }
        [HttpPut("VehicleType")]
        public VehicleType UpdateVehicleType(int id, VehicleTypeUpdateRequest request)
        {
            return _service.UpdateVehicleType(id, request);
        }

        //Manufacturer
        [HttpGet("Manufacturers")]
        public List<Manufacturer> GetManufactures()
        {
            return _service.GetManufacturerTypeList();
        }
        [HttpPost("Manufacturer")]
        public Manufacturer InsertManufacturer(ManufacturerInsertRequest request)
        {
            return _service.InsertManufacturer(request);
        }
        [HttpPut("Manufacturer")]
        public Manufacturer UpdateManufacturer(int id, ManufacturerUpdateRequest request)
        {
            return _service.UpdateManufacturer(id, request);
        }
    }
}
