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
    public class RadniProstorController : BaseCRUDController<Model.RadniProstor, RadniProstorSearchObject,
        RadniProstorUpsertRequest, RadniProstorUpsertRequest>
    {
        public RadniProstorController(IRadniProstorService service) : base(service)
        {
        }
    }
}
