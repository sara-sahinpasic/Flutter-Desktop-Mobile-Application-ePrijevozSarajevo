using ePrijevozSarajevo.Model.Exceptions;
using ePrijevozSarajevo.Model.Requests;
using ePrijevozSarajevo.Model.SearchObjects;
using ePrijevozSarajevo.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

namespace ePrijevozSarajevo.Services
{
    public class RouteService : BaseCRUDService<Model.Route, RouteSearchObject, Database.Route, RouteInsertRequest, RouteUpdateRequest>, IRouteService
    {
        public RouteService(DataContext context, IMapper mapper, IRecommenderService recommenderService) 
            : base(context, mapper)         {        }

        public override IQueryable<Database.Route> AddFilter(RouteSearchObject search, IQueryable<Database.Route> query)
        {
            query = base.AddFilter(search, query);

            if ((search?.StartStationIdGTE >= 0) && (search.DateGTE.Year > 1))
            {
                if(search.EndStationIdGTE == null)
                {
                    query = query.Where(x => x.StartStationId == search.StartStationIdGTE)
                             .Where(x => x.Departure.Date.Equals(search.DateGTE.Date))
                             .Where(x => x.Departure.Date >= search.DateGTE.Date && x.Departure.TimeOfDay >= search.DateGTE.TimeOfDay);

                }else
                {
                    query = query.Where(x => x.StartStationId == search.StartStationIdGTE && x.EndStationId == search.EndStationIdGTE)
                             .Where(x => x.Departure.Date.Equals(search.DateGTE.Date))
                             .Where(x => x.Departure.Date >= search.DateGTE.Date && x.Departure.TimeOfDay >= search.DateGTE.TimeOfDay);

                }
            }
            if (search.IsStationIncluded == true)
            {
                query = query.Include(x => x.StartStation)
                   .Include(y => y.EndStation);
            }
            if (search.IsVehicleIncluded == true)
            {
                query = query.Include(x => x.Vehicle)
                             .ThenInclude(y => y.Type)
                             .Include(x => x.Vehicle.Manufacturer);
            }

            return query;
        }
        public async Task DeleteRouteWithIssuedTickets(int routeId)
        {
            // Route from past
            DateTime todayDate = DateTime.Now;

            var route = await _dataContext.Routes.FindAsync(routeId);

            if (route == null)
            {
                throw new UserException("Ruta nije pronađena.");
            }

            if (route.Departure <= todayDate)
            {
                throw new UserException("Nije moguće izbrisati rutu s prošlim datumom polaska.");
            }

            _dataContext.Routes.Remove(route);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Model.Route> InsertArrivalDeparture(RouteInsertRequest request)
        {
            Database.Route entity = _mapper.Map<Database.Route>(request);
            await BeforeInsert(request, entity);

            if (entity.Arrival < entity.Departure)
            {
                throw new UserException("Vrijeme dolaska ne može biti manje od vremena polaska.");
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
                throw new UserException("Vrijeme dolaska ne može biti biti manje od vremena polaska.");
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