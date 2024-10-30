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

            //FOR MOBILE ROUTE_SCREEN
            if ((search?.StartStationIdGTE >= 0) && (search.DateGTE.Year > 1))
            {

                var date = search.DateGTE.Date;
                var time = search.DateGTE.TimeOfDay;

                query = query.Where(x => x.StartStationId == search.StartStationIdGTE)
                             .Where(x => x.Departure.Date.Equals(date))
                             //mobile: 
                             .Where(x => x.Departure.Date == date && x.Departure.TimeOfDay >= time);

            }
            /* if (search.IsStationIncluded == true)
             {
                 query = query.Include(x => x.StartStation);
             }*/

            return query;//.OrderByDescending(x=>x.Departure);
        }

        public async Task DeleteRouteWithIssuedTickets(int routeId)
        {
            // Find and delete issued tickets related to the route
            var issuedTickets = _dataContext.IssuedTickets.Where(t => t.RouteId == routeId);
            _dataContext.IssuedTickets.RemoveRange(issuedTickets);

            // Find and delete the route
            var route = await _dataContext.Routes.FindAsync(routeId);
            if (route != null)
            {
                _dataContext.Routes.Remove(route);
            }

            await _dataContext.SaveChangesAsync();
        }
    }
}
