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

            /*if (!string.IsNullOrWhiteSpace(search?.StartStationIdGTE.ToString()))
            {
                query = query.Where(x => x.StartStation.StationId.ToString().StartsWith(search.StartStationIdGTE.ToString()));
            }*/

            if (search.IsStationIncluded == true)
            {
                query = query.Include(x => x.StartStation);
            }

            return query;
        }
    }
}
