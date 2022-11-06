namespace eShopCoffe.Core.Email.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendRequestPasswordResetEmail(string email, string username, string passwordResetCode);
        Task<bool> SendAccountCreationEmail(string email, string username);
    }
}
