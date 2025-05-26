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
    public class StatusRezervacijeController : BaseCRUDController<Model.StatusRezervacije,
        StatusRezervacijeSearchObject, StatusRezervacijeUpsertRequest, StatusRezervacijeUpsertRequest>
    {
        public StatusRezervacijeController(IStatusRezervacijeService service) : base(service)
        {
        }
    }
}
