using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRoleController : BaseCRUDController<UserRole, UserRoleSearchObjects, UserRoleUpsertRequest, UserRoleUpsertRequest>
    {
        public UserRoleController(IUserRoleService service) : base(service)
        {
        }
    }
}
