namespace ePrijevozSarajevo.Model.Requests
{
    public class RouteUpdateRequest
    {
        //public int? StartStationId { get; set; }
        //public int? EndStationId { get; set; }
        //public int? VehicleId { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        //public bool? Active { get; set; }
        //public bool? ActiveOnHolidays { get; set; }
        //public bool? ActiveOnWeekends { get; set; }
    }
}
