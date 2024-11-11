namespace ePrijevozSarajevo.Model.Requests
{
    public class RequestInsertRequest
    {
        public int UserStatusId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool? Approved { get; set; } = false;
        public bool? Active { get; set; } = true;
    }
}
