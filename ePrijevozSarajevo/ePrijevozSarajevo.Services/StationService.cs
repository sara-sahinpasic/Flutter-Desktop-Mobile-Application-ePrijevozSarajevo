using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;

namespace ePrijevozSarajevo.Services
{
    public class StationService : BaseCRUDService<Model.Station, StationSearchObject, Database.Station, StationInsertRequest, StationUpdateRequest>, IStationService
    {
        public StationService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Station> AddFilter(StationSearchObject search, IQueryable<Station> query)
        {
            query = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search?.NameGTE))
            {
                query = query.Where(x => x.Name.StartsWith(search.NameGTE));
            }

            /*if (!string.IsNullOrWhiteSpace(search.DateGTE.Date.ToString()))
            {
                query = query.OrderBy(x => x.Date);
            }*/

            return query;
        }


    }
}
