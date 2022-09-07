using eShopCoffe.Basket.Domain.Commands.BasketCommands;

namespace eShopCoffe.Basket.Domain.Tests.Commands.BasketCommands
{
    public class AddOrUpdateBasketItemCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var amount = 1;

            // Act
            var command = new AddOrUpdateBasketItemCommand(productId, amount);

            // Assert
            command.ProductId.Should().Be(productId);
            command.Amount.Should().Be(amount);
        }
    }
}
