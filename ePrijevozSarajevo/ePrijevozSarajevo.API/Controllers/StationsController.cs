using ePrijevozSarajevo.Model;
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
    }
}
