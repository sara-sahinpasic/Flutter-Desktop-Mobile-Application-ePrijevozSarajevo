using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoodTracker30012025Controller : BaseCRUDController<Model.MoodTracker30012025, MoodTracker30012025SearchObject,
        MoodTracker30012025UpsertRequest, MoodTracker30012025UpsertRequest>

    {
        public MoodTracker30012025Controller(IMoodTrackerService service) : base(service) { }

        [HttpGet("count-raspolozenje")]
        public async Task<CountRaspolozenja> CountRaspolozenja()
        {

            return await (_service as IMoodTrackerService).GetCountRaspolozenja();

        }
    }
}
