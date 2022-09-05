using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Catalog.Domain.Validators.ProductValidators;
using FluentValidation.TestHelper;

namespace eShopCoffe.Catalog.Domain.Tests.Validators.ProductValidators
{
    public class RemoveProductCommandValidatorTests
    {
        private static readonly Guid ValidId = Guid.NewGuid();

        private readonly RemoveProductCommandValidator _validator;

        public RemoveProductCommandValidatorTests()
        {
            _validator = new RemoveProductCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new RemoveProductCommand(ValidId);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyId()
        {
            // Arrange
            var command = new RemoveProductCommand(Guid.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }
    }
}
