namespace ePrijevozSarajevo.Model
{
    public class IssuedTicket
    {
        public int IssuedTicketId { get; set; }
        public User User { get; set; } = null!;
        public Ticket Ticket { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
