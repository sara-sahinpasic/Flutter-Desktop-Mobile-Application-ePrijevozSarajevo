namespace ePrijevozSarajevo.Model.Requests
{
    public class UserUpdateRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public Country? Country { get; set; }
        public int UserCountryId { get; set; }
        public byte[]? ProfileImage { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        public string? Password { get; set; }
        public string? PasswordConfirmation { get; set; }
    }
}
