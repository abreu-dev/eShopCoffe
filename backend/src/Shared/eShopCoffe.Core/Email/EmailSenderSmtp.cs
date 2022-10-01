using eShopCoffe.Core.Email.Interfaces;
using System.Net;
using System.Net.Mail;

namespace eShopCoffe.Core.Email
{
    public class EmailSenderSmtp : IEmailSender
    {
        private readonly IEmailSettings _emailSettings;

        public EmailSenderSmtp(IEmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        public async Task<bool> SendEmail(MailMessage email)
        {
            email.From = new MailAddress(_emailSettings.Address);

            var smtp = new SmtpClient
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = _emailSettings.Host,
                Port = _emailSettings.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_emailSettings.Address, _emailSettings.Password)
            };

            try
            {
                await smtp.SendMailAsync(email);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
