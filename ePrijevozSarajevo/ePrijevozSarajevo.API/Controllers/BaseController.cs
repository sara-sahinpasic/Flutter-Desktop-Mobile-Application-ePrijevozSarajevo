using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ePrijevozSarajevo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController<TModel, TSearch> : ControllerBase
        where TSearch : BaseSearchObject
    {
        protected IService<TModel, TSearch> _service;

        public BaseController(IService<TModel, TSearch> service)
        {
            this._service = service;
        }

        [HttpGet]
        public async virtual Task <PagedResult<TModel>> GetList([FromQuery]TSearch searchObject)
        {
            return await _service.GetPaged(searchObject);
        }

        [HttpGet("{id}")]
        public async virtual Task <TModel> GetById(int id)
        {
            return await _service.GetById(id);
        }


    }
}
