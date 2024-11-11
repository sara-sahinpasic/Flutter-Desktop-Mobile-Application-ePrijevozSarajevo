namespace ePrijevozSarajevo.Services.Database
{
    public class Request
    {
        public int RequestId { get; set; }
        public User? User { get; set; } = null;
        public int UserId { get; set; }
        public Status? UserStatus { get; set; }
        public int? UserStatusId { get; set; }
        public DateTime? DateCreated { get; set; } 
        public bool? Active { get; set; } = true;
        public bool? Approved { get; set; } = false;
        public string? RejectionReason { get; set; }
    }
}
