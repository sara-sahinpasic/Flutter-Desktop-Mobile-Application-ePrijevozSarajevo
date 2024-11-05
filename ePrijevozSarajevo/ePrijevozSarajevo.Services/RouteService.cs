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
            // Route from past
            DateTime todayDate = DateTime.Now;

            var route = await _dataContext.Routes.FindAsync(routeId);

            if (route == null)
            {
                throw new InvalidOperationException("Ruta nije pronađena.");
            }

            if (route.Departure <= todayDate)
            {
                throw new InvalidOperationException("Nije moguće izbrisati rutu s prošlim datumom polaska.");
            }

            // Find and delete issued tickets related to the route
            var issuedTickets = _dataContext.IssuedTickets.Where(t => t.RouteId == routeId);
            _dataContext.IssuedTickets.RemoveRange(issuedTickets);

            _dataContext.Routes.Remove(route);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Model.Route> InsertArrivalDeparture(RouteInsertRequest request)
        {
            Database.Route entity = _mapper.Map<Database.Route>(request);
            await BeforeInsert(request, entity);

            if (entity.Arrival < entity.Departure)
            {
                throw new InvalidOperationException("Vrijeme dolaska ne može biti biti manje od vremena polaska.");
            }
            else
            {
                await _dataContext.AddAsync(entity);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Model.Route>(entity);

        }

        public async Task<Model.Route> UpdateArrivalDeparture(int id, RouteUpdateRequest request)
        {
            var set = _dataContext.Set<Database.Route>();
            var entity = await set.FindAsync(id);

            if (entity != null && request.Arrival < request.Departure)
            {
                throw new InvalidOperationException("Update:: Vrijeme dolaska ne može biti biti manje od vremena polaska.");
            }
            else
            {
                _mapper.Map(request, entity);
                await BeforeUpdate(request, entity);
                await _dataContext.SaveChangesAsync();
            }
            return _mapper.Map<Model.Route>(entity);
        }
    }
}
