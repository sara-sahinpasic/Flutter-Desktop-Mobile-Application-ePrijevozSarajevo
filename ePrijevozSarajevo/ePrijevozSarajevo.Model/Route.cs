namespace ePrijevozSarajevo.Model
{
    public class Route
    {
        public int RouteId { get; set; }
        public Station? StartStation { get; set; }
        public Station? EndStation { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeOfArrival { get; set; }
        public TimeSpan TimeOfDeparture { get; set; }
        public bool Active { get; set; }
        public bool ActiveOnHolidays { get; set; }
        public bool ActiveOnWeekend { get; set; }
        //public int VehicleId { get; set; }
        //public Vehicle Vehicle { get; set; }

    }
}
