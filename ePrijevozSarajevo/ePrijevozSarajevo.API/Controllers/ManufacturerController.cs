using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : BaseCRUDController<Model.Manufacturer, ManufacturerSearchObject, ManufacturerUpsertRequest, ManufacturerUpsertRequest>
    {
        public ManufacturerController(IManufacturerService service) : base(service)
        {
        }

        [AllowAnonymous]
        public override PagedResult<Manufacturer> GetList([FromQuery] ManufacturerSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }

        [Authorize(Roles = "Admin")]
        public override Manufacturer Insert(ManufacturerUpsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
