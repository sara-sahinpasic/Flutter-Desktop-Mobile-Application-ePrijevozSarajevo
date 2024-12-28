using MailKit.Net.Smtp;
using MimeKit;

namespace ePrijevozSarajevo.Services.Email
{
    public class EmailService : IEmailService
    {
        public EmailService() { }
        public void SendNoReplyMail(string toEmail, string subject, string content)
        {
            var fromEmail = "eprijevoztest@e-mail.de";
            MailboxAddress from = new("No-reply ePrijevozSarajevo", fromEmail);
            MailboxAddress to = new("Customer", toEmail);
            var pw = "DJPMZCGdRpy9AO5Y";

            MimeMessage message = new();
            TextPart bodyPart = new("html")
            {
                Text = content
            };
            message.From.Add(from);
            message.To.Add(to);
            message.Body = bodyPart;
            message.Subject = subject;

            using SmtpClient client = new();

            client.Connect("smtp-relay.brevo.com", 587, false);
            client.Authenticate("826009002@smtp-brevo.com", pw);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
