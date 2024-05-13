namespace ePrijevozSarajevo.Model.Requests
{
    public class UserUpdateRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
        public int? UserStatusId { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
        public string Password { get; set; } = null!;
        public string PasswordConfirmation { get; set; } = null!;
        public string? UserName { get; set; }
    }
}
