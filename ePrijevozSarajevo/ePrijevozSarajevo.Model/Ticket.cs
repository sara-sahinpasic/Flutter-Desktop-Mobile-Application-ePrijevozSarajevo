namespace ePrijevozSarajevo.Model
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        //public bool Active { get; set; }
        public string? StateMachine { get; set; }

    }
}
