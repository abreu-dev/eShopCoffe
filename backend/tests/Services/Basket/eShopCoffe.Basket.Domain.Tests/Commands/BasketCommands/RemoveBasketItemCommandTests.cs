using eShopCoffe.Basket.Domain.Commands.BasketCommands;

namespace eShopCoffe.Basket.Domain.Tests.Commands.BasketCommands
{
    public class RemoveBasketItemCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act
            var command = new RemoveBasketItemCommand(productId);

            // Assert
            command.ProductId.Should().Be(productId);
        }
    }
}
