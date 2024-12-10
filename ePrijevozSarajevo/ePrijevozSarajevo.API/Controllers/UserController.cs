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
        public async Task<Model.User> Login(string username, string password)
        {
            return await (_service as IUserService).Login(username, password);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                await (_service as IUserService).ResetPassword(request.Username, request.NewPassword, request.PasswordConfirmation);
                return Ok(new { message = "Password reset successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public override async Task Delete(int id)
        {
            await(_service as IUserService).DeleteUser(id);
        }

        [HttpPost]
        public override async Task<User> Insert(UserInseretRequest request)
        {
            return await (_service as IUserService).InsertDateOfBirth(request);
        }
    }
}
