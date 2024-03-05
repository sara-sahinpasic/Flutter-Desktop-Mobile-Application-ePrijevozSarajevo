using ePrijevozSarajevo.Model;

namespace ePrijevozSarajevo.Services
{
    public class StationsService : IStationsService
    {
        public List<Stations> StationsList = new List<Stations>()
        {
            new Stations()
            {
                StationId = 1,
                Date = DateTime.Now.Date,
                Time = DateTime.Now.TimeOfDay,
                Name = "Otoka"
            }
        };
        public List<Stations> GetStationsList()
        {
            return StationsList;
        }
    }
}
