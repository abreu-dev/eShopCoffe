using eShopCoffe.Core.Validators;
using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Domain.Validators.Interfaces;
using System.Text.RegularExpressions;

namespace eShopCoffe.Identity.Domain.Validators
{
    public class SignUpValidator : ISignUpValidator
    {
        private static string ValidUsernameRegex => @"^[a-z].{6,12}$";
        private static string ValidEmailRegex => @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;

        public SignUpValidator(IUserRepository userRepository, IPasswordValidator passwordValidator)
        {
            _userRepository = userRepository;
            _passwordValidator = passwordValidator;
        }

        public IResult Validate(string username, string email, string password)
        {
            var usernameRegex = new Regex(ValidUsernameRegex);
            if (string.IsNullOrEmpty(username) || !usernameRegex.IsMatch(username))
                return Result.Failure(
                    "SignUpValidatorFailed",
                    "Username must have minimum six and maximum twelve characters and be formed only by lower case letters.");

            var emailRegex = new Regex(ValidEmailRegex);
            if (string.IsNullOrEmpty(email) || !emailRegex.IsMatch(email))
                return Result.Failure(
                    "SignUpValidatorFailed",
                    "Email must be valid.");

            var passwordValidatorResult = _passwordValidator.Validate(password);
            if (!passwordValidatorResult.HasSucceed) 
                return passwordValidatorResult;

            if (_userRepository.ExistsByUsername(username))
                return Result.Failure(
                    "SignUpValidatorFailed",
                    "Username already in use.");

            if (_userRepository.ExistsByEmail(email))
                return Result.Failure(
                    "SignUpValidatorFailed",
                    "Email already in use.");

            return Result.Success();
        }
    }
}
