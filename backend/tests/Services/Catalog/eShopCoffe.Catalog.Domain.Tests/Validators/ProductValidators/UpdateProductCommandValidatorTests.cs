using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Catalog.Domain.Validators.ProductValidators;

namespace eShopCoffe.Catalog.Domain.Tests.Validators.ProductValidators
{
    public class UpdateProductCommandValidatorTests
    {
        private static readonly Guid ValidId = Guid.NewGuid();
        private static readonly string ValidName = "Name";
        private static readonly string ValidDescription = "Description";
        private static readonly string ValidImageUrl = "ImageUrl";
        private static readonly int ValidQuantityAvailable = 0;
        private static readonly decimal ValidCurrencyValue = 1;
        private static readonly string ValidCurrencyCode = "CurrencyCode";

        private readonly UpdateProductCommandValidator _validator;

        public UpdateProductCommandValidatorTests()
        {
            _validator = new UpdateProductCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new UpdateProductCommand(
                ValidId,
                ValidName,
                ValidDescription,
                ValidImageUrl,
                ValidQuantityAvailable,
                ValidCurrencyValue,
                ValidCurrencyCode);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyId()
        {
            // Arrange
            var command = new UpdateProductCommand(
                Guid.Empty,
                ValidName,
                ValidDescription,
                ValidImageUrl,
                ValidQuantityAvailable,
                ValidCurrencyValue,
                ValidCurrencyCode);

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
            var command = new UpdateProductCommand(
                ValidId,
                string.Empty,
                ValidDescription,
                ValidImageUrl,
                ValidQuantityAvailable,
                ValidCurrencyValue,
                ValidCurrencyCode);

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
            var command = new UpdateProductCommand(
                ValidId,
                ValidName,
                string.Empty,
                ValidImageUrl,
                ValidQuantityAvailable,
                ValidCurrencyValue,
                ValidCurrencyCode);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyImageUrl()
        {
            // Arrange
            var command = new UpdateProductCommand(
                ValidId,
                ValidName,
                ValidDescription,
                string.Empty,
                ValidQuantityAvailable,
                ValidCurrencyValue,
                ValidCurrencyCode);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ImageUrl)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenQuantityAvailableLessThanZero()
        {
            // Arrange
            var command = new UpdateProductCommand(
                ValidId,
                ValidName,
                ValidDescription,
                ValidImageUrl,
                -1,
                ValidCurrencyValue,
                ValidCurrencyCode);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.QuantityAvailable)
                .WithErrorCode("GreaterThanOrEqualValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenCurrencyValueLessThanOne()
        {
            // Arrange
            var command = new UpdateProductCommand(
                ValidId,
                ValidName,
                ValidDescription,
                ValidImageUrl,
                ValidQuantityAvailable,
                0,
                ValidCurrencyCode);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CurrencyValue)
                .WithErrorCode("GreaterThanValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyCurrencyCode()
        {
            // Arrange
            var command = new UpdateProductCommand(
                ValidId,
                ValidName,
                ValidDescription,
                ValidImageUrl,
                ValidQuantityAvailable,
                ValidCurrencyValue,
                string.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.CurrencyCode)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }
    }
}
