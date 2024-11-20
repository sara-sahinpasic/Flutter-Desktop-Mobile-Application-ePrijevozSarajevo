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
    public class TypeController : BaseCRUDController<Model.Type, 
        TypeSearchObject, TypeUpsertRequest, TypeUpsertRequest>
    {
        public TypeController(ITypeService service) : base(service)
        {
        }
        [AllowAnonymous]
        public override Task<PagedResult<Model.Type>> GetList([FromQuery] TypeSearchObject searchObject)
        {
            return base.GetList(searchObject);
        }
        [Authorize(Roles = "Admin")]
        public override async Task<Model.Type> Insert(TypeUpsertRequest request)
        {
            return await base.Insert(request);
        }
    }
}
