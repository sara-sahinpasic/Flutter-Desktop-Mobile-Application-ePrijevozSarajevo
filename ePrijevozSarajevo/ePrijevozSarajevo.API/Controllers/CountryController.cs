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
    public class CountryController : BaseCRUDController<Model.Country,
        CountrySearchObject, CountryUpsertRequest, CountryUpsertRequest>
    {
        public CountryController(ICountryService service) : base(service) { }

        [AllowAnonymous]
        public override Task<PagedResult<Country>> GetList([FromQuery] CountrySearchObject searchObject)
        {
            return base.GetList(searchObject);
        }
        [Authorize(Roles = "Admin")]
        public override Task<Country> Insert(CountryUpsertRequest request)
        {
            return base.Insert(request);
        }
    }
}
