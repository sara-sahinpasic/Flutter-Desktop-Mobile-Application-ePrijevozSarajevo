namespace ePrijevozSarajevo.Services.Database
{
    public class Request
    {
        public int RequestId { get; set; }

        public int UserStatusId { get; set; }
        public Status UserStatus { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime DateCreated { get; set; }
        public bool Approved { get; set; }

        public string DocumentLink { get; set; } = null!;
        public string? RejectionReason { get; set; }
        public bool Active { get; set; }
    }
}
