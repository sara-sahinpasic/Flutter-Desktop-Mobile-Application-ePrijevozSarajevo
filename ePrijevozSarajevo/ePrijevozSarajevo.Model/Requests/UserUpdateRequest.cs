namespace ePrijevozSarajevo.Model.Requests
{
    public class UserUpdateRequest
    {
        //public int RoleId { get; set; }
        //public Role? Role { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public bool Active { get; set; }
        public string? ProfileImagePath { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirmation { get; set; }
        //public int UserStatusId { get; set; }
        //public Status? UserStatus { get; set; }
        //public DateTime? StatusExpirationDate { get; set; }
    }
}
