namespace ePrijevozSarajevo.Model
{
    public class Routes
    {
        public int RouteId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeOfArrival { get; set; }
        public TimeSpan TimeOfDeparture { get; set; }

        //public int VehicleId { get; set; }
        //public Vehicle Vehicle { get; set; }

        //public int StartStationId { get; set; }
        //public Station StartStation { get; set; }

        //public int EndStationId { get; set; }
        //public Station EndStation { get; set; }
        public bool Active { get; set; }
        public bool ActiveOnHolidays { get; set; }
        public bool ActiveOnWeekend { get; set; }

    }
}
