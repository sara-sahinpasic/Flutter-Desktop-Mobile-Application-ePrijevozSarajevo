namespace ePrijevozSarajevo.Model.Requests
{
    public class UserUpdateRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public int? UserStatusId { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public string? Password { get; set; }
        public string? PasswordConfirmation { get; set; }
        // public bool Active { get; set; }
        // public DateTime? StatusExpirationDate { get; set; }
        //string Password { get; set; } = null!;
    }
}
