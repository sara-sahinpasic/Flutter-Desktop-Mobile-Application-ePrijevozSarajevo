namespace ePrijevozSarajevo.Services.Database
{
    public class Request
    {
        public int RequestId { get; set; }
        public int UserStatusId { get; set; }
        public Status? UserStatus { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } = null;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool Approved { get; set; } = false;
        public string? DocumentLink { get; set; }
        public string? RejectionReason { get; set; }
        public bool Active { get; set; } = true;
    }
}
