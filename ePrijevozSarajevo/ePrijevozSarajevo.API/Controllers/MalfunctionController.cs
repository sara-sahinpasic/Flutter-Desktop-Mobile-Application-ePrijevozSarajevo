using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MalfunctionController : BaseCRUDController
        <Model.Malfunction, MalfunctionSearchObject,
        MalfunctionInsertRequest, MalfunctionUpdateRequest>
    {
        public MalfunctionController(IMalfunctionService service) 
            : base(service)
        {
        }
    }
}
