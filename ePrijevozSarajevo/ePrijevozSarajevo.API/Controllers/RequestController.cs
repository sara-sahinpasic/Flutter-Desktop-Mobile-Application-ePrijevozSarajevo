using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequestController : BaseCRUDController<Model.Request, RequestSearchObject, RequestInsertRequest, RequestUpdateRequest>
    {
        public RequestController(IRequestService service) : base(service)
        {
        }
    }
}

