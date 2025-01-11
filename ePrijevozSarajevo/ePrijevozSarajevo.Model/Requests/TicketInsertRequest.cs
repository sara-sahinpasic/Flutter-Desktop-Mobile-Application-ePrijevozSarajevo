namespace ePrijevozSarajevo.Model.Requests
{
    public class TicketInsertRequest
    {
        public string? Name { get; set; } 
        public double Price { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
