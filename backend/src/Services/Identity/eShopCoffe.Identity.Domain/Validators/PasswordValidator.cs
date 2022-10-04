using eShopCoffe.Core.Validators;
using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Domain.Validators.Interfaces;
using System.Text.RegularExpressions;

namespace eShopCoffe.Identity.Domain.Validators
{
    public class PasswordValidator : IPasswordValidator
    {
        private static string MinimumEightCaractersAtLeastOneUpperCaseAndOneLowerCaseLetterAndOneDigitAndOneSpecialCharacter
            => @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

        public IResult Validate(string password)
        {
            var regex = new Regex(MinimumEightCaractersAtLeastOneUpperCaseAndOneLowerCaseLetterAndOneDigitAndOneSpecialCharacter);
            
            if (!string.IsNullOrEmpty(password) && regex.IsMatch(password)) return Result.Success();

            return Result.Failure(
                "PasswordValidatorFailed",
                "Password must have minimum eight characters, at least one upper case letter, one lower case letter, one digit and one special character.");
        }
    }
}
