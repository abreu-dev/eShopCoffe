using eShopCoffe.Core.Email.Interfaces;
using System.Net.Mail;
using System.Text;

namespace eShopCoffe.Core.Email
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task<bool> SendAccountCreationEmail(string email, string username)
        {
            var emailBody = new StringBuilder()
                .Append("<h1>Bem vindo a eShopCoffe</h1><br>")
                .Append($"<p>Bem vindo {username}! Sua conta foi criada com sucesso.<p></b><br>")
                .Append("<p>Acesse já em nosso aplicativo.<p><br><br>")
                .ToString();

            var emailSubject = "[eShopCoffe] Sua conta foi criada";

            return await SendMail(email, emailSubject, emailBody, true);
        }

        public async Task<bool> SendRequestPasswordResetEmail(string email, string username, string passwordResetCode)
        {
            var emailBody = new StringBuilder()
                .Append("<h1>Reset your eShopCoffe password</h1><br>")
                .Append("<p>We heard that you forgot your eShopCoffe password. <b>Don't worry about that!<br><p></b><br>")
                .Append("<p>You can use the following code to reset it on our app:<p><br><br>")
                .Append($"<p>{passwordResetCode}<p><br>")
                .Append("<p>It will expire in 15 minutes.<p>")
                .ToString();

            var emailSubject = "[eShopCoffe] Please reset your password";

            return await SendMail(email, emailSubject, emailBody, true);
        }

        private async Task<bool> SendMail(string toEmailAddress, string emailSubject, string emailBody, bool isEmailBodyHtml)
        {
            var email = new MailMessage
            {
                Subject = emailSubject,
                Body = emailBody,
                IsBodyHtml = isEmailBodyHtml
            };
            email.To.Add(toEmailAddress);

            return await _emailSender.SendEmail(email);
        }
    }
}
