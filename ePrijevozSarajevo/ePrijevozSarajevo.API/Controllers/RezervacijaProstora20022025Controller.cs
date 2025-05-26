using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RezervacijaProstora20022025Controller : BaseCRUDController<Model.RezervacijaProstora20022025,
        RezervacijaProstora20022025SearchObject, RezervacijaProstora20022025UpsertRequest,
        RezervacijaProstora20022025UpsertRequest>
    {
        public RezervacijaProstora20022025Controller(IRezervacijeProstoraService service) : base(service)
        {
        }
        [HttpGet("total-list")]
        public async Task<List<TotalDto>> TotalList([FromQuery] RezervacijaProstora20022025SearchObject searchObject)

        {
            return await (_service as IRezervacijeProstoraService).TotalList(searchObject);
        }
    }
}
