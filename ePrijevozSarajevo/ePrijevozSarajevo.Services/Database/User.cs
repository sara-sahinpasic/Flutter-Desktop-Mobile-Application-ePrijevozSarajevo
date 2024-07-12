namespace ePrijevozSarajevo.Services.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public bool? Active { get; set; }
        public Status? UserStatus { get; set; }
        public int? UserStatusId { get; set; }
        public string? ProfileImagePath { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
        //
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        //public string Password { get; set; }

    }
}
