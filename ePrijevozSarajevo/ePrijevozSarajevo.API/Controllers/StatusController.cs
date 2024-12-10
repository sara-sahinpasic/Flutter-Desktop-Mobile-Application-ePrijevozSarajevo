using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : BaseCRUDController<Model.Status, StatusSearchObject, StatusInsertRequest, StatusUpdateRequest>
    {
        public StatusController(IStatusService service) : base(service) { }
    }
}
