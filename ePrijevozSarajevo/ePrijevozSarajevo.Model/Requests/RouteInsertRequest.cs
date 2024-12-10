namespace ePrijevozSarajevo.Model.Requests
{
    public class RouteInsertRequest
    {
        public int StartStationId { get; set; }
        public int EndStationId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Departure { get; set; } = DateTime.Now;
        public DateTime Arrival { get; set; } = DateTime.Now;
    }
}
