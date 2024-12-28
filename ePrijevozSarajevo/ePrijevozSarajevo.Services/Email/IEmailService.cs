namespace ePrijevozSarajevo.Services.Email
{
    public interface IEmailService
    {
        void SendNoReplyMail(string to, string subject, string content);
    }
}
