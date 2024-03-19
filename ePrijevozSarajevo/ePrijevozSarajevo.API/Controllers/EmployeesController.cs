using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        protected IEmployeesService _service;

        public EmployeesController(IEmployeesService service)
        {
            this._service = service;
        }
        [HttpGet]
        public List<User> GetEmployees()
        {
            return _service.GetList();
        }
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
