using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TypeController : BaseCRUDController<Model.Type, TypeSearchObject, TypeUpsertRequest, TypeUpsertRequest>
    {
        public TypeController(ITypeService service) : base(service)
        {
        }
        [AllowAnonymous]
        public override PagedResult<Model.Type> GetList([FromQuery] TypeSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }
        [Authorize(Roles = "Admin")]
        public override Model.Type Insert(TypeUpsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
