using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StationsController : ControllerBase
    {
        protected IStationsService _service;

        public StationsController(IStationsService service)
        {
            this._service = service;
        }
        [HttpGet]
        public List<Station> GetStations()
        {
            return _service.GetList();
        }
        [HttpPost]
        public Station Insert(StationInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut]
        public Station Update(int id, StationUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
