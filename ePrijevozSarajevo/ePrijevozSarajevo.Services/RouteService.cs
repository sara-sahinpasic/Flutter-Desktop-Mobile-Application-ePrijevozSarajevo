using ePrijevozSarajevo.Model;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace ePrijevozSarajevo.Services
{
    public class RouteService : BaseCRUDService<Model.Route, RouteSearchObject, Database.Route, RouteInsertRequest, RouteUpdateRequest>, IRouteService
    {
        public RouteService(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Database.Route> AddFilter(RouteSearchObject search, IQueryable<Database.Route> query)
        {
            query = base.AddFilter(search, query);

           /* if (!string.IsNullOrWhiteSpace(search?.StartStationGTE.ToString()))
            {
                query = query.Where(x => x.StartStation.ToString().StartsWith(search.StartStationGTE.ToString()));
            }

            if (!string.IsNullOrWhiteSpace(search?.EndStationGTE.ToString()))
            {
                query = query.Where(x => x.EndStation.ToString().StartsWith(search.EndStationGTE.ToString()));
            }*/

            if (search.IsStartStationIncluded == true)
            {
                query = query.Include(x => x.StartStation).ThenInclude(x => x.Name);
            }
            if (search.IsEndStationIncluded == true)
            {
                query = query.Include(x => x.StartStation).ThenInclude(x => x.Name);
            }

            return query;
        }
    }
}
