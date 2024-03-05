using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class RoutesService : IRoutesService
    {
        public List<Routes> RoutesList = new List<Routes>()
        {
            new Routes ()
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

        public List<Routes> GetRoutesList()
        {
            return RoutesList;
        }
    }
}
