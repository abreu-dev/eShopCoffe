using eShopCoffe.Core.Email;
using eShopCoffe.Core.Email.Interfaces;
using System.Net.Mail;

namespace eShopCoffe.Core.Tests.Email
{
    public class EmailServiceTests
    {
        private readonly IEmailSender _emailSender;
        private readonly EmailService _emailService;

        public EmailServiceTests()
        {
            _emailSender = Substitute.For<IEmailSender>();
            _emailService = new EmailService(_emailSender);
        }

        [Fact]
        public void SendRequestPasswordResetEmail_ShouldSendEmail()
        {
            // Arrange
            var email = "email@email.com";
            var username = "username";
            var passwordResetCode = "123456";

            var emailSenderResult = true;
            _emailSender.SendEmail(Arg.Is<MailMessage>(x => !string.IsNullOrEmpty(x.Subject)
                                                            && !string.IsNullOrEmpty(x.Body)
                                                            && x.Body.Contains(passwordResetCode)
                                                            && x.IsBodyHtml
                                                            && x.To.Any(x => x.Address == email)))
                .Returns(emailSenderResult);

            // Act
            var result = _emailService.SendRequestPasswordResetEmail(email, username, passwordResetCode).Result;

            // Assert
            result.Should().Be(emailSenderResult);
        }
    }
}
