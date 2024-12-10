using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;

namespace ePrijevozSarajevo.Services
{
    public interface ICountryService : ICRUDService<Model.Country,
        CountrySearchObject, CountryUpsertRequest, CountryUpsertRequest>
    { }
}
