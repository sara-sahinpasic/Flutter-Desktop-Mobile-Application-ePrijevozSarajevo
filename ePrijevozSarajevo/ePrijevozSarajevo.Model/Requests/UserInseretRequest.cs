namespace ePrijevozSarajevo.Model.Requests
{
    public class UserInseretRequest
    {
        public int RoleId { get; set; } = 1;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public bool? Active { get; set; }
        public string? ProfileImagePath { get; set; }
        public string? Password { get; set; } = null!;
        public string? PasswordConfirmation { get; set; } = null!;
        public int? UserStatusId { get; set; } = 1;
    }
}
