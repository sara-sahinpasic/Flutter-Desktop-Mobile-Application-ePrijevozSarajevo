namespace ePrijevozSarajevo.Services.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public Country? UserCountry { get; set; }
        public int? UserCountryId { get; set; }
        public DateTime RegistrationDate { get; set; } 
        public DateTime ModifiedDate { get; set; } 
        public Status? UserStatus { get; set; }
        public int? UserStatusId { get; set; }
        public byte[]? ProfileImage { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
