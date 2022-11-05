using eShopCoffe.Core.Email.Interfaces;
using eShopCoffe.Core.Validators;
using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Application.Services.Interfaces;
using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Domain.Validators.Interfaces;
using System.Security.Cryptography;

namespace eShopCoffe.Identity.Application.Services
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IEmailService _emailService;

        public PasswordResetService(
            IUserRepository userRepository,
            IPasswordValidator passwordValidator,
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
            _emailService = emailService;
        }

        public async Task RequestPasswordReset(string username)
        {
            if (!_userRepository.ExistsByUsername(username)) return;

            var temporaryPasswordResetCode = GenerateTemporaryPasswordResetCode();
            _userRepository.ChangeTemporaryPasswordResetCode(username, temporaryPasswordResetCode);
            _userRepository.UnitOfWork.Complete();

            var email = _userRepository.GetEmailByUsername(username);
            await _emailService.SendRequestPasswordResetEmail(email, username, temporaryPasswordResetCode);
        }

        public IResult ConfirmPasswordReset(string username, string newPassword, string passwordResetCode)
        {
            if (!_userRepository.ExistsByUsername(username))
                return Result.Failure("ConfirmPasswordResetFailed", "Usuário não encontrado.");

            if (!_userRepository.ValidateTemporaryPasswordResetCode(username, passwordResetCode))
                return Result.Failure("ConfirmPasswordResetFailed", "Código de confirmação inválido.");

            var passwordValidator = _passwordValidator.Validate(newPassword);

            if (!passwordValidator.HasSucceed) return passwordValidator;

            _userRepository.ChangePassword(username, newPassword);
            _userRepository.UnitOfWork.Complete();

            return Result.Success();
        }

        private static string GenerateTemporaryPasswordResetCode()
        {
            var randomNumber = RandomNumberGenerator.GetInt32(0, 1000000);
            var sixDigitNumber = randomNumber.ToString("D6");
            return sixDigitNumber;
        }
    }
}
