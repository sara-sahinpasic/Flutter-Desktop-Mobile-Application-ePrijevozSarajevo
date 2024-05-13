using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleTypeController : BaseCRUDController<VehicleType, VehicleTypeSearchObject, VehicleTypeUpsertRequest, VehicleTypeUpsertRequest>
    {
        public VehicleTypeController(IVehicleTypeService service) : base(service)
        {
        }

        [AllowAnonymous]
        public override PagedResult<VehicleType> GetList([FromQuery] VehicleTypeSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }
        [Authorize(Roles = "Admin")]
        public override VehicleType Insert(VehicleTypeUpsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
