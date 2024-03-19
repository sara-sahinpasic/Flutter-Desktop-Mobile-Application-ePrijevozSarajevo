namespace ePrijevozSarajevo.Model
{
    public class Request
    {
        public int RequestId { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }

        //public int UserStatusId { get; set; }
        //public Status UserStatus { get; set; }

        //public int CategoryId { get; set; }
        //public Category CategoryName { get; set; }

        public bool Approved { get; set; }
        public string? DocumentLink { get; set; }
        public bool Active { get; set; }
    }
}
