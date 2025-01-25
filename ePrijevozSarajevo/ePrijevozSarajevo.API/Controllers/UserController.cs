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
    public class UserController : BaseCRUDController<User, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        public UserController(IUserService service) : base(service) { }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<Model.User> Login(string username, string password)
        {
            return await (_service as IUserService).Login(username, password);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task ResetPassword([FromBody] ResetPasswordRequest request)
        {
         
            await (_service as IUserService).ResetPassword(request.Username, request.NewPassword, request.PasswordConfirmation,request.OldPassword);
            
        }
        [HttpDelete("{id}")]
        public override async Task Delete(int id)
        {
            await(_service as IUserService).DeleteUser(id);
        }

        [AllowAnonymous]
        [HttpPost]
        public override async Task<User> Insert(UserInsertRequest request)
        {
            return await (_service as IUserService).InsertUser(request);
        }
    }
}
