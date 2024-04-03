namespace ePrijevozSarajevo.Services.Database
{
    public class User
    {
        public int UserId { get; set; }

        public int RoleId { get; set; } 
        public Role? Role { get; set; }

        public string? FirstName { get; set; } 

        public string? LastName { get; set; } 

        public string? Email { get; set; } 

        public string? PasswordHash { get; set; } 

        public string? PasswordSalt { get; set; } 

        public DateTime DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }

        public int UserStatusId { get; set; }
        public Status? UserStatus { get; set; }

        public string? ProfileImagePath { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
    }
}
