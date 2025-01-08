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

        public override IQueryable<Database.Country> AddFilter(CountrySearchObject search, IQueryable<Country> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.CountryNameGTE))
            {
                query = query.Where(x => x.Name.Contains(search.CountryNameGTE));
            }
            return query;
        }
    }
}
