using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.IdentityModel.Tokens;

namespace ePrijevozSarajevo.Services
{
    public class StationService : BaseCRUDService<Model.Station, StationSearchObject, Database.Station, StationInsertRequest, StationUpdateRequest>, IStationService
    {
        public StationService(DataContext context, IMapper mapper) : base(context, mapper) { }
        public override IQueryable<Station> AddFilter(StationSearchObject search, IQueryable<Station> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.NameGTE))
            {
                query = query.Where(x => x.Name.StartsWith(search.NameGTE));
            }

            return query;
        }

        public override Task Delete(int id)
        {
            var routes = _dataContext.Routes.Where(x => x.StartStationId == id || x.EndStationId == id);
            if (!routes.IsNullOrEmpty())
            {
                throw new UserException("Nije moguće obrisati stanicu koja se koristi. Potrebno obrisati prvo rute.");
            }
            return base.Delete(id);
        }
    }
}
