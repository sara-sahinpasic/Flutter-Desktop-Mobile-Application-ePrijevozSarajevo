using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class CountryService : BaseCRUDService<Model.Country,
        CountrySearchObject, Database.Country, CountryUpsertRequest,
        CountryUpsertRequest>, ICountryService
    {
        public CountryService(DataContext context, IMapper mapper) : base(context, mapper) { }
    }
}
