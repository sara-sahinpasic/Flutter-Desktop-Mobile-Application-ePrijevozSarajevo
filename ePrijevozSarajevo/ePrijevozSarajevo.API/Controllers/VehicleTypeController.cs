using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleTypeController : BaseCRUDController<Model.VehicleType, VehicleTypeSearchObject, VehicleTypeUpsertRequest, VehicleTypeUpsertRequest>
    {
        public VehicleTypeController(IVehicleTypeService service) : base(service)
        {
        }

    }
}
