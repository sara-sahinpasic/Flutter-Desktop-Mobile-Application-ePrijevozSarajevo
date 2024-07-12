namespace ePrijevozSarajevo.Model
{
    public class Request
    {
        public int RequestId { get; set; }
        public Status? UserStatus { get; set; }
        public int UserStatusId { get; set; }
        public User? User { get; set; } = null;
        public int UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool Approved { get; set; } = false;
        public string? DocumentLink { get; set; }
        public string? RejectionReason { get; set; }
        public bool? Active { get; set; } = true;
    }
}
