namespace ePrijevozSarajevo.Model
{
    public class Delay
    {
        public int DelayId { get; set; }
        public string Reason { get; set; } = null!;
        public Route? Route { get; set; } 
        public int? RouteId { get; set; }
        public int? DelayAmountMinutes { get; set; }
        public Type? Type { get; set; }
        public int? TypeId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }   
}
