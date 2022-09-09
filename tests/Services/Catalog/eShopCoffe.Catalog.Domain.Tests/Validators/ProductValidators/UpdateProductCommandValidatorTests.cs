using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Catalog.Domain.Validators.ProductValidators;

namespace eShopCoffe.Catalog.Domain.Tests.Validators.ProductValidators
{
    public class UpdateProductCommandValidatorTests
    {
        private static readonly Guid ValidId = Guid.NewGuid();
        private static readonly string ValidName = "Name";
        private static readonly string ValidDescription = "Description";
        private static readonly int ValidQuantityAvailable = 0;

        private readonly UpdateProductCommandValidator _validator;

        public UpdateProductCommandValidatorTests()
        {
            _validator = new UpdateProductCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new UpdateProductCommand(ValidId, ValidName, ValidDescription, ValidQuantityAvailable);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyId()
        {
            // Arrange
            var command = new UpdateProductCommand(Guid.Empty, ValidName, ValidDescription, ValidQuantityAvailable);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Id)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyName()
        {
            // Arrange
            var command = new UpdateProductCommand(ValidId, string.Empty, ValidDescription, ValidQuantityAvailable);

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
            var command = new UpdateProductCommand(ValidId, ValidName, string.Empty, ValidQuantityAvailable);

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
            var command = new UpdateProductCommand(ValidId, ValidName, ValidDescription, -1);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.QuantityAvailable)
                .WithErrorCode("GreaterThanOrEqualValidator")
                .Only();
        }
    }
}
