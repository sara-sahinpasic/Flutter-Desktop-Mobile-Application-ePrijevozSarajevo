namespace ePrijevozSarajevo.Model.Requests
{
    public class RequestUpdateRequest
    {
        public int UserStatusId { get; set; }
        public bool Approved { get; set; }
        public string? RejectionReason { get; set; }
        public bool Active { get; set; }
    }
}
