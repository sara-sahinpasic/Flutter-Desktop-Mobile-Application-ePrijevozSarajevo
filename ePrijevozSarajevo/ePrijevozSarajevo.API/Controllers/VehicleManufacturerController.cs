using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleManufacturerController : BaseCRUDController<Model.VehicleManufacturer, VehicleManufacturerSearchObject, VehicleManufacturerUpsertRequest, VehicleManufacturerUpsertRequest>
    {
        public VehicleManufacturerController(IVehicleManufacturerService service) : base(service)
        {
        }

    }
}
