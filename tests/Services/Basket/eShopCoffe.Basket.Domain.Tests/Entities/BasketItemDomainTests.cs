using eShopCoffe.Basket.Domain.Entities;

namespace eShopCoffe.Basket.Domain.Tests.Entities
{
    public class BasketItemDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var basketId = Guid.NewGuid();
            var amount = 0;

            // Act
            var basketItemDomain = new BasketItemDomain(productId, basketId, amount);

            // Assert
            basketItemDomain.ProductId.Should().Be(productId);
            basketItemDomain.BasketId.Should().Be(basketId);
            basketItemDomain.Amount.Should().Be(amount);
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var basketId = Guid.NewGuid();
            var amount = 0;

            // Act
            var basketItemDomain = new BasketItemDomain(id, productId, basketId, amount);

            // Assert
            basketItemDomain.Id.Should().Be(id);
            basketItemDomain.ProductId.Should().Be(productId);
            basketItemDomain.BasketId.Should().Be(basketId);
            basketItemDomain.Amount.Should().Be(amount);
        }

        [Fact]
        public void SetAmount_ShouldSetAmountValue()
        {
            // Arrange
            var basketItemDomain = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), 5);
            var newAmount = 15;

            // Act
            basketItemDomain.SetAmount(newAmount);

            // Assert
            basketItemDomain.Amount.Should().Be(newAmount);
        }
    }
}
