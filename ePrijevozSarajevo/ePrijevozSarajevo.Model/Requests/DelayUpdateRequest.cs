namespace ePrijevozSarajevo.Model.Requests
{
    public class DelayUpdateRequest
    {
        public string Reason { get; set; } = null!;
        public int? DelayAmountMinutes { get; set; }

    }
}
