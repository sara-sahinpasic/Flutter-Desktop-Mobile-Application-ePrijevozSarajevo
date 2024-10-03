namespace ePrijevozSarajevo.Model.Requests
{
    public class IssuedTicketInsertequest
    {
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime IssuedDate { get; set; }
        public int Amount { get; set; }
        public int RouteId { get; set; }
    }
}
