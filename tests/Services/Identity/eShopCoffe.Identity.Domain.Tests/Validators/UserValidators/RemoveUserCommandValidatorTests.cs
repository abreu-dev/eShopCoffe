using eShopCoffe.Identity.Domain.Commands.UserCommands;
using eShopCoffe.Identity.Domain.Validators.UserValidators;
using FluentValidation.TestHelper;

namespace eShopCoffe.Identity.Domain.Tests.Validators.UserValidators
{
    public class RemoveUserCommandValidatorTests
    {
        private static readonly Guid ValidId = Guid.NewGuid();

        private readonly RemoveUserCommandValidator _validator;

        public RemoveUserCommandValidatorTests()
        {
            _validator = new RemoveUserCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new RemoveUserCommand(ValidId);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyId()
        {
            // Arrange
            var command = new RemoveUserCommand(Guid.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }
    }
}
