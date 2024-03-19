using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class RoutesService : IRoutesService
    {
        public List<Route> RoutesList = new List<Route>()
        {
            new Route ()
            {
                RouteId = 1,
                Date = DateTime.Now.Date,
                TimeOfArrival = DateTime.Now.TimeOfDay,
                TimeOfDeparture = DateTime.Now.TimeOfDay,
                Active = true,
                ActiveOnHolidays = true,
                ActiveOnWeekend = true
            }
        };

        public List<Route> GetRoutesList()
        {
            return RoutesList;
        }
    }
}
