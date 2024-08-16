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

            // search.DateGTE.Year > 1 cause default value is 01/01/0001
            if ((search?.StartStationIdGTE >= 0) && (search.DateGTE.Year > 1))
            {
                var date = search.DateGTE.Date;
                query = query.Where(x => x.StartStationId == search.StartStationIdGTE)
                             .Where(x => x.Departure.Date.Equals(date));
            }

            /*
            FOR MOBILE ROUTE_SCREEN
            if ((search?.StartStationIdGTE >= 0) && (search.DateGTE.Year > 1))
            {
                var date = search.DateGTE.Date;
                //
                //var date = search.DateGTE.Date;
                //var time = search.DateGTE.TimeOfDay; // Assuming DateGTE has a TimeOfDay component or equivalent

                query = query.Where(x => x.StartStationId == search.StartStationIdGTE)
                             .Where(x => x.EndStationId == search.EndStationIdGTE)
                             .Where(x => x.Departure.Date.Equals(date));
                             //.Where(x => x.Departure.Date == date && x.Departure.TimeOfDay >= time);
            }
             */

            //2024-07-10 17:36:06.4220079
            //{7/10/2024 5:36:06 PM}


            //if (search.IsStationIncluded == true)
            //{
            //    query = query.Include(x => x.StartStation);
            //}

            return query;
        }
    }
}
