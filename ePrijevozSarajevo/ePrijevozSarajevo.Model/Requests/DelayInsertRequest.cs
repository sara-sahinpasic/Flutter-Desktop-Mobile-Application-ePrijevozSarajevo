namespace ePrijevozSarajevo.Model.Requests
{
    public class DelayInsertRequest
    {
        public int DelayId { get; set; }
        public string Reason { get; set; } = null!;
        public int? RouteId { get; set; }
        public int? DelayAmountMinutes { get; set; }
        public int? TypeId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CurrentUserId { get; set; }
    }
}
