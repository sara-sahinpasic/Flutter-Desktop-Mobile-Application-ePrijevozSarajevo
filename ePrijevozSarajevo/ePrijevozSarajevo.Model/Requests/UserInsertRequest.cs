﻿namespace ePrijevozSarajevo.Model.Requests
{
    public class UserInsertRequest
    {
        public int RoleId { get; set; } = 1;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; }
        public byte[]? ProfileImage { get; set; }
        public string? Password { get; set; } = null!;
        public string? PasswordConfirmation { get; set; } = null!;
        public int? UserStatusId { get; set; } = 1;
        public int? UserCountryId { get; set; } = 1;
        public string? UserName { get; set; }
        public DateTime? StatusExpirationDate { get; set; }
    }
}
