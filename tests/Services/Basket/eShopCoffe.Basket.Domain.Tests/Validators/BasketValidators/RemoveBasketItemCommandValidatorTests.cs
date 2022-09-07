using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Basket.Domain.Validators.BasketValidators;

namespace eShopCoffe.Basket.Domain.Tests.Validators.BasketValidators
{
    public class RemoveBasketItemCommandValidatorTests
    {
        private static readonly Guid ValidProductId = Guid.NewGuid();

        private readonly RemoveBasketItemCommandValidator _validator;

        public RemoveBasketItemCommandValidatorTests()
        {
            _validator = new RemoveBasketItemCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new RemoveBasketItemCommand(ValidProductId);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyId()
        {
            // Arrange
            var command = new RemoveBasketItemCommand(Guid.Empty);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.ProductId)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }
    }
}
