namespace ePrijevozSarajevo.Model.Requests
{
    public class RouteInsertRequest
    {
        public int StartStationId { get; set; }
        public int EndStationId { get; set; }
        public TimeSpan TimeOfDeparture { get; set; }
        public TimeSpan TimeOfArrival { get; set; }
        public int VehicleId { get; set; }
        public bool Active { get; set; }
        public bool ActiveOnHolidays { get; set; }
        public bool ActiveOnWeekends { get; set; }
    }
}
