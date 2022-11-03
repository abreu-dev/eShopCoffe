using eShopCoffe.Ordering.Domain.Commands.OrderCommands;

namespace eShopCoffe.Ordering.Domain.Tests.Commands.OrderCommands
{
    public class AddOrderCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var cep = "Cep";
            var number = "Number";
            var paymentMethod = "PaymentMethod";
            var items = new List<AddOrderCommand.OrderItem>();
            var clearBasket = true;

            // Act
            var command = new AddOrderCommand(cep, number, paymentMethod, items, clearBasket);

            // Assert
            command.Cep.Should().Be(cep);
            command.Number.Should().Be(number);
            command.PaymentMethod.Should().Be(paymentMethod);
            command.Items.Should().BeEquivalentTo(items);
            command.ClearBasket.Should().Be(clearBasket);
        }
    }
}
