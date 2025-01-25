namespace ePrijevozSarajevo.Model.Requests
{
    public class ResetPasswordRequest
    {
        public string Username { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string PasswordConfirmation { get; set; } = null!;
        public string OldPassword { get; set; } = null!;

    }
}
