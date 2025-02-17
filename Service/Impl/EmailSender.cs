using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using RecruitmentSystem.Config;

namespace RecruitmentSystem.Service.Impl
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            using (var client = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port))
            {
                client.Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
                client.EnableSsl = _emailSettings.EnableSSL;

                var message = new MailMessage(_emailSettings.SenderEmail, to, subject, body);
                message.IsBodyHtml = true;

                await client.SendMailAsync(message);
            }
        }
    }
}
