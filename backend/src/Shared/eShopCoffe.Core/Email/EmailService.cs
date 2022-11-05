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

        public async Task<bool> SendRequestPasswordResetEmail(string email, string username, string passwordResetCode)
        {
            var emailBody = new StringBuilder()
                .Append("<h1>Altere sua senha do eShopCoffe</h1><br>")
                .Append("<p>Nós ouvimos que você esqueceu sua senha do eShopCoffe. <b>Não se preocupe!<br><p></b><br>")
                .Append("<p>Você deve usar o seguinte código para alterá-la em nosso aplicativo:<p><br><br>")
                .Append($"<p>{passwordResetCode}<p><br>")
                .Append("<p>O código irá expirar em 15 minutos.<p>")
                .ToString();

            var emailSubject = "[eShopCoffe] Altere sua senha";

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
