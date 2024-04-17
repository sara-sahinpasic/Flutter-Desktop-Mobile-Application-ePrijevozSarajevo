namespace ePrijevozSarajevo.Services.Database
{
    public class Route
    {
        public int RouteId { get; set; }
        public int StartStationId { get; set; }
        public Station StartStation { get; set; } = null!;
        public int EndStationId { get; set; }
        public Station EndStation { get; set; } = null!;
        public TimeSpan? TimeOfDeparture { get; set; }
        public TimeSpan? TimeOfArrival { get; set; }
        public int VehicleId { get; set; }
        //public Vehicle Vehicle { get; set; } = null!;
        public bool Active { get; set; }
        public bool ActiveOnHolidays { get; set; }
        public bool ActiveOnWeekends { get; set; }

    }
}
