using eShopCoffe.Basket.Domain.Events.BasketEvents;

namespace eShopCoffe.Basket.Domain.Tests.Events.BasketEvents
{
    public class ClearBasketEventTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var userId = Guid.NewGuid();

            // Act
            var @event = new ClearBasketEvent(userId);

            // Assert
            @event.UserId.Should().Be(userId);
        }
    }
}
