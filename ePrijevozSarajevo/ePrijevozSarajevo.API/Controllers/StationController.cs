using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StationController : BaseCRUDController<Model.Station, StationSearchObject, StationInsertRequest, StationUpdateRequest>
    {
        public StationController(IStationService service) : base(service) { }

    }
}
