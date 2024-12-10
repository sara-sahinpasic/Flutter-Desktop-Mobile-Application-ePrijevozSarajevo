using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehicleController : BaseCRUDController<Vehicle, VehicleSearchObject, VehicleInsertRequest, VehicleUpdateRequest>
    {
        public VehicleController(IVehicleService service) : base(service) { }

        [AllowAnonymous]
        public override Task<PagedResult<Vehicle>> GetList([FromQuery] VehicleSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }

        [Authorize(Roles = "Admin")]
        public override async Task<Vehicle> Insert(VehicleInsertRequest request)
        {
            return await base.Insert(request);
        }
    }
}
