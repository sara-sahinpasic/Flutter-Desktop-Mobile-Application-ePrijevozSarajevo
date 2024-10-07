using System.ComponentModel.DataAnnotations.Schema;

namespace ePrijevozSarajevo.Services.Database
{
    public class IssuedTicket
    {
        public int IssuedTicketId { get; set; }
        public User? User { get; set; }
        public int? UserId { get; set; }
        public Ticket? Ticket { get; set; } 
        public int? TicketId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime IssuedDate { get; set; } = DateTime.UtcNow;
        public int? Amount { get; set; }
        public Route? Route { get; set; }
        public int? RouteId { get; set; }
    }
}
