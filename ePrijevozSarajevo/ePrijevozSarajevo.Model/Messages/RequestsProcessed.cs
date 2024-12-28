namespace ePrijevozSarajevo.Model.Messages
{
    public class RequestsProcessed
    {
        public string userEmail { get; set; }
        public int userId { get; set; }
        public string requestedStatusName { get; set; }
        public bool requestApproved { get; set; }
    }
}
