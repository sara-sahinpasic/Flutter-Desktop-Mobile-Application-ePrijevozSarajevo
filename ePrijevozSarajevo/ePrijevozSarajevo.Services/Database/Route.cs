namespace ePrijevozSarajevo.Services.Database
{
    public class Route
    {
        public int RouteId { get; set; }
        public Station? StartStation { get; set; } 
        public int StartStationId { get; set; }
        public Station? EndStation { get; set; }
        public int EndStationId { get; set; }
        public Vehicle? Vehicle { get; set; } 
        public int VehicleId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
