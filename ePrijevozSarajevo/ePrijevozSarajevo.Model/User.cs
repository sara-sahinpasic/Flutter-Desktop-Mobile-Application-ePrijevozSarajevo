namespace ePrijevozSarajevo.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public Country? Country { get; set; }
        public int CountryId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
        //public string? ProfileImagePath { get; set; }
        public byte[]? ProfileImage { get; set; }
        public Status? UserStatus { get; set; }
        public int UserStatusId { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public string? UserName { get; set; }
    }
}
