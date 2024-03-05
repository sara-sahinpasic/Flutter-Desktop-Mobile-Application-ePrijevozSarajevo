using ePrijevozSarajevo.Model;
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
        public List<Employees> GetEmployees()
        {
            return _service.GetEmployeesList();
        }
    }
}
