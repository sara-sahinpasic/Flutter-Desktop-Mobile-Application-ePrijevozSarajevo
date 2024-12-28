using MailKit.Net.Smtp;
using MimeKit;

namespace ePrijevozSarajevo.Services.Email
{
    public class EmailService : IEmailService
    {
        public EmailService() { }
        public void SendNoReplyMail(string toEmail, string subject, string content)
        {
            var fromEmail = Environment.GetEnvironmentVariable("FROM_EMAIL")
                ??"eprijevoztest@e-mail.de"
                ;
            var smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER")
                ??"smtp-relay.brevo.com"
                ;
            var smtpUsername = Environment.GetEnvironmentVariable("SMTP_USERNAME")
                ??"826009002@smtp-brevo.com"
                ;
            var smtpPassword = Environment.GetEnvironmentVariable("SMTP_PASSWORD")
                ??"DJPMZCGdRpy9AO5Y"
                ;
            var port = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT")
                ??"587"
                );

            MailboxAddress from = new("No-reply ePrijevozSarajevo", fromEmail);
            MailboxAddress to = new("Customer", toEmail);
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

            client.Connect(smtpServer, port, false);
            client.Authenticate(smtpUsername, smtpPassword);
            client.Send(message);
            client.Disconnect(true);
        }
    }
}
