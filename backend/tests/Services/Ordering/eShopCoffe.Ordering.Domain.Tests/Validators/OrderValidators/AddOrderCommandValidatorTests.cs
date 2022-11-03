using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Ordering.Domain.Commands.OrderCommands;
using eShopCoffe.Ordering.Domain.Validators.OrderValidators;
using FluentValidation.TestHelper;

namespace eShopCoffe.Ordering.Domain.Tests.Validators.OrderValidators
{
    public class AddOrderCommandValidatorTests
    {
        private static readonly string ValidCep = "Cep";
        private static readonly string ValidNumber = "Number";
        private static readonly string ValidPaymentMethod = "Credit Card";
        private static readonly IEnumerable<AddOrderCommand.OrderItem> ValidItems = new List<AddOrderCommand.OrderItem>()
        {
            new AddOrderCommand.OrderItem(Guid.NewGuid(), 1)
        };
        private static readonly bool ValidClearBasket = true;

        private readonly AddOrderCommandValidator _validator;

        public AddOrderCommandValidatorTests()
        {
            _validator = new AddOrderCommandValidator();
        }

        [Fact]
        public void Validate_ShouldBeValid()
        {
            // Arrange
            var command = new AddOrderCommand(ValidCep, ValidNumber, ValidPaymentMethod, ValidItems, ValidClearBasket);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyCep()
        {
            // Arrange
            var command = new AddOrderCommand(string.Empty, ValidNumber, ValidPaymentMethod, ValidItems, ValidClearBasket);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Cep)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyPaymentMethod()
        {
            // Arrange
            var command = new AddOrderCommand(ValidCep, ValidNumber, string.Empty, ValidItems, ValidClearBasket);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.PaymentMethod)
                .WithErrorCode("NotEmptyValidator");
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenInvalidPaymentMethod()
        {
            // Arrange
            var command = new AddOrderCommand(ValidCep, ValidNumber, "Card", ValidItems, ValidClearBasket);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.PaymentMethod)
                .WithErrorCode("PredicateValidator");
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyItems()
        {
            // Arrange
            var command = new AddOrderCommand(ValidCep, ValidNumber, ValidPaymentMethod, new List<AddOrderCommand.OrderItem>(), ValidClearBasket);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Items)
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenEmptyItemProductId()
        {
            // Arrange
            var command = new AddOrderCommand(ValidCep, ValidNumber, ValidPaymentMethod, new List<AddOrderCommand.OrderItem>()
            {
                new AddOrderCommand.OrderItem(Guid.Empty, 15)
            }, ValidClearBasket);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor("Items[0].ProductId")
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }

        [Fact]
        public void Validate_ShouldBeInvalid_WhenItemAmountLessThanOne()
        {
            // Arrange
            var command = new AddOrderCommand(ValidCep, ValidNumber, ValidPaymentMethod, new List<AddOrderCommand.OrderItem>()
            {
                new AddOrderCommand.OrderItem(Guid.NewGuid(), 0)
            }, ValidClearBasket);

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor("Items[0].Amount")
                .WithErrorCode("GreaterThanValidator")
                .Only();
        }
    }
}
