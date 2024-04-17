namespace ePrijevozSarajevo.Model.Requests
{
    public class RequestInsertRequest
    {
        //public int UserStatusId { get; set; }
        //public Status UserStatus { get; set; } = null!;
        //public int UserId { get; set; }
        //public User User { get; set; } = null!;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public bool Approved { get; set; } = false;
        public string DocumentLink { get; set; } = null!;
        public bool Active { get; set; } = true;

        public int UserStatusId { get; set; }
        public int UserId { get; set; }
    }
}
