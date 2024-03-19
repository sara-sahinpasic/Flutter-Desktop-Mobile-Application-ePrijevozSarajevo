using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class StationsService : IStationsService
    {
        public List<Station> StationsList = new List<Station>()
        {
            new Station()
            {
                StationId = 1,
                Date = DateTime.Now.Date,
                Time = DateTime.Now.TimeOfDay,
                Name = "Otoka"
            }
        };
        public List<Station> GetStationsList()
        {
            return StationsList;
        }
    }
}
