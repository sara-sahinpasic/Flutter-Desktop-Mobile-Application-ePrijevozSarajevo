using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DelayController : BaseCRUDController<Model.Delay,
        DelaySearchObject, DelayInsertRequest, DelayUpdateRequest>
    {
        public DelayController(IDelayService service) : base(service)
        {
        }
    }
}
