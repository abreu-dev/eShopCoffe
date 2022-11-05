using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Basket.Domain.Validators.BasketValidators;

namespace eShopCoffe.Basket.Domain.Tests.Validators.BasketValidators
{
    public class AddOrUpdateBasketItemCommandValidatorTests
    {
        private static readonly Guid ValidProductId = Guid.NewGuid();
        private static readonly int ValidAmount = 1;
        private static readonly bool ValidIncrease = true;

        private readonly AddOrUpdateBasketItemCommandValidator _validator;

        public AddOrUpdateBasketItemCommandValidatorTests()
        {
            _validator = new AddOrUpdateBasketItemCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new AddOrUpdateBasketItemCommand(ValidProductId, ValidAmount, ValidIncrease);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyId()
        {
            // Arrange
            var command = new AddOrUpdateBasketItemCommand(Guid.Empty, ValidAmount, ValidIncrease);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ProductId)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenQuantityAvailableLessThanOne()
        {
            // Arrange
            var command = new AddOrUpdateBasketItemCommand(ValidProductId, 0, ValidIncrease);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Amount)
                .WithErrorCode("GreaterThanValidator")
                .Only();
        }
    }
}
