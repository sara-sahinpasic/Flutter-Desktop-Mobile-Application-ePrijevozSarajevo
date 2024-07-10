namespace ePrijevozSarajevo.Services.Database
{
    public class Route
    {
        public int RouteId { get; set; }
        public Station StartStation { get; set; } = null!;
        public int StartStationId { get; set; }
        public Station EndStation { get; set; } = null!;
        public int EndStationId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;
        public int VehicleId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public bool Active { get; set; }
        public bool ActiveOnHolidays { get; set; }
        public bool ActiveOnWeekends { get; set; }

    }
}
