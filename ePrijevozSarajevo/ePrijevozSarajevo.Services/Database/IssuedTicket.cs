using System.ComponentModel.DataAnnotations.Schema;

namespace ePrijevozSarajevo.Services.Database
{
    public class IssuedTicket
    {
        public int IssuedTicketId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime IssuedDate { get; set; }
        [NotMapped]
        public int Amount { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; } = null!;
    }
}
