using System.Net.Mail;

namespace eShopCoffe.Core.Email.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(MailMessage email);
    }
}
