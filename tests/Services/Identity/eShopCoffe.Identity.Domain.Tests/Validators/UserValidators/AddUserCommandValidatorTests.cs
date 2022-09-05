using eShopCoffe.Identity.Domain.Commands.UserCommands;
using eShopCoffe.Identity.Domain.Validators.UserValidators;
using FluentValidation.TestHelper;

namespace eShopCoffe.Identity.Domain.Tests.Validators.UserValidators
{
    public class AddUserCommandValidatorTests
    {
        private static readonly string ValidLogin = "Login";
        private static readonly string ValidPassword = "Password";

        private readonly AddUserCommandValidator _validator;

        public AddUserCommandValidatorTests()
        {
            _validator = new AddUserCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new AddUserCommand(ValidLogin, ValidPassword);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyLogin()
        {
            // Arrange
            var command = new AddUserCommand(string.Empty, ValidPassword);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Login)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyPassword()
        {
            // Arrange
            var command = new AddUserCommand(ValidLogin, string.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Password)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }
    }
}
