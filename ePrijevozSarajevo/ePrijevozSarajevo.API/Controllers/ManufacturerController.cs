using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturerController : BaseCRUDController<Model.Manufacturer, ManufacturerSearchObject, ManufacturerInsertRequest, ManufacturerUpdateRequest>
    {
        public ManufacturerController(IManufacturerService service) : base(service)
        {
        }
    }
}
