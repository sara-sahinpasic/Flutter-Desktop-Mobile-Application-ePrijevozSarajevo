namespace ePrijevozSarajevo.Model.Messages
{
    public class RequestsProcessed
    {
        public string UserEmail { get; set; }
        public int UserId { get; set; }
        public string RequestedStatusName { get; set; }
        public bool RequestApproved { get; set; }
        public string Reason { get; set; }
    }
}
