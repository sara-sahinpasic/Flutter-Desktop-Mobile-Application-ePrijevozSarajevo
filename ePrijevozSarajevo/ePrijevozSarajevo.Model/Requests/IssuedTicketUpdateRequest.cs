namespace ePrijevozSarajevo.Model.Requests
{
    public class IssuedTicketUpdateRequest
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int RouteId { get; set; }
    }
}
