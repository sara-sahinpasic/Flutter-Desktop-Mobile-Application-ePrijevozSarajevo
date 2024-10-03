namespace ePrijevozSarajevo.Model
{
    public class IssuedTicket
    {
        public int IssuedTicketId { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Ticket Ticket { get; set; } = null!;
        public int TicketId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime IssuedDate { get; set; } = DateTime.Now;
        //public Route Route { get; set; } = null!;
        //public int RouteId { get; set; }

    }
}
