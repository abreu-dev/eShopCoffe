using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Catalog.Domain.Validators.ProductValidators;
using FluentValidation.TestHelper;

namespace eShopCoffe.Catalog.Domain.Tests.Validators.ProductValidators
{
    public class AddProductCommandValidatorTests
    {
        private static readonly string ValidName = "Name";
        private static readonly string ValidDescription = "Description";
        private static readonly int ValidQuantityAvailable = 0;

        private readonly AddProductCommandValidator _validator;

        public AddProductCommandValidatorTests()
        {
            _validator = new AddProductCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new AddProductCommand(ValidName, ValidDescription, ValidQuantityAvailable);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyName()
        {
            // Arrange
            var command = new AddProductCommand(string.Empty, ValidDescription, ValidQuantityAvailable);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyDescription()
        {
            // Arrange
            var command = new AddProductCommand(ValidName, string.Empty, ValidQuantityAvailable);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenQuantityAvailableLessThanZero()
        {
            // Arrange
            var command = new AddProductCommand(ValidName, ValidDescription, -1);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.QuantityAvailable)
                .WithErrorCode("GreaterThanOrEqualValidator")
                .Only();
        }
    }
}
