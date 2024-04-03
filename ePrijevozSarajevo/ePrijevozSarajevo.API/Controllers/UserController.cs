using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : /*ControllerBase*/ BaseController<Model.User, UserSearchObject>
    {
        protected IUserService _service;

        public UserController(IUserService service) : base(service) { }
        /*{
            this._service = service;
        }*/
        /*[HttpGet]
        public List<User> GetEmployees()
        {
            return _service.GetList();
        }*/
        /*[HttpGet]
        public PagedResult<User> GetEmployees([FromQuery] UserSearchObject searchObject)
        {
            return _service.GetList(searchObject);
        }*/


        [HttpPost]
        public Model.User Insert(UserInseretRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut]
        public Model.User Update(int id, UserUpdateRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
