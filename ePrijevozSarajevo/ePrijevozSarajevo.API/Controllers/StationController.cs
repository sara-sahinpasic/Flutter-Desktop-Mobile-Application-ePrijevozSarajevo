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
    public class StationController : BaseCRUDController<Model.Station, StationSearchObject, StationInsertRequest, StationUpdateRequest>
    {
        public StationController(IStationService service) : base(service) { }

        [AllowAnonymous]
        public override Task<PagedResult<Station>> GetList([FromQuery] StationSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }

        [Authorize(Roles = "Admin")]
        public override Task<Station> Insert(StationInsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
