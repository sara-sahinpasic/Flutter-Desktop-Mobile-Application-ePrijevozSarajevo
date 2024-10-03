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
    public class UserController : BaseCRUDController<User, UserSearchObject, UserInseretRequest, UserUpdateRequest>
    {
        public UserController(IUserService service) : base(service) { }

        [HttpPost("login")]
        [AllowAnonymous]
        public Model.User Login(string username, string password)
        {
            return (_service as IUserService).Login(username, password);
        }
    }
}
