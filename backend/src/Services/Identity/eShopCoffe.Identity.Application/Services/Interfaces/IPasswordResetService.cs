using eShopCoffe.Core.Validators.Interfaces;

namespace eShopCoffe.Identity.Application.Services.Interfaces
{
    public interface IPasswordResetService
    {
        Task RequestPasswordReset(string username);
        IResult ConfirmPasswordReset(string username, string newPassword, string passwordResetCode);
    }
}
