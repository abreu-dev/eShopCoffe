using eShopCoffe.Basket.Domain.Entities;

namespace eShopCoffe.Basket.Domain.Tests.Entities
{
    public class BasketDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange
            var userId = Guid.NewGuid();

            // Act
            var basketDomain = new BasketDomain(userId);

            // Assert
            basketDomain.UserId.Should().Be(userId);
            basketDomain.Items.Should().BeEmpty();
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var basketItemDomainList = new List<BasketItemDomain>()
            {
                new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), 0)
            };

            // Act
            var basketDomain = new BasketDomain(id, userId, basketItemDomainList);

            // Assert
            basketDomain.Id.Should().Be(id);
            basketDomain.UserId.Should().Be(userId);
            basketDomain.Items.Should().BeEquivalentTo(basketItemDomainList);
        }

        [Fact]
        public void AddOrUpdateItem_WhenNotExists_ShouldAdd()
        {
            // Arrange
            var newProductId = Guid.NewGuid();
            var newAmount = 15;

            var basketItemDomain1 = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), 0);
            var basketItemDomain2 = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), 0);
            var basketItemDomainList = new List<BasketItemDomain>()
            {
                basketItemDomain1, basketItemDomain2
            };
            var basketDomain = new BasketDomain(Guid.NewGuid(), Guid.NewGuid(), basketItemDomainList);

            // Act
            basketDomain.AddOrUpdateItem(newProductId, newAmount);

            // Assert
            basketDomain.Items.Should().HaveCount(3);
            basketDomain.Items.Should().Contain(basketItemDomain1);
            basketDomain.Items.Should().Contain(basketItemDomain2);
            basketDomain.Items.Should().Contain(x => x.ProductId == newProductId && x.Amount == newAmount && x.BasketId == basketDomain.Id);
        }

        [Fact]
        public void AddOrUpdateItem_WhenExists_ShouldUpdateAmount()
        {
            // Arrange
            var initialAmount = 5;
            var newAmount = 15;

            var basketItemDomain1 = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), initialAmount);
            var basketItemDomain2 = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), initialAmount);
            var basketItemDomainList = new List<BasketItemDomain>()
            {
                basketItemDomain1, basketItemDomain2
            };
            var basketDomain = new BasketDomain(Guid.NewGuid(), Guid.NewGuid(), basketItemDomainList);

            // Act
            basketDomain.AddOrUpdateItem(basketItemDomain2.ProductId, newAmount);

            // Assert
            basketDomain.Items.Should().HaveCount(2);
            basketDomain.Items.Should().Contain(basketItemDomain1);
            basketItemDomain1.Amount.Should().Be(initialAmount);

            basketDomain.Items.Should().Contain(basketItemDomain2);
            basketItemDomain2.Amount.Should().Be(newAmount);
        }

        [Fact]
        public void RemoveItemByProductId_WhenExists_ShouldRemove()
        {
            // Arrange
            var basketItemDomain1 = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), 0);
            var basketItemDomain2 = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), 0);
            var basketItemDomainList = new List<BasketItemDomain>()
            {
                basketItemDomain1, basketItemDomain2
            };
            var basketDomain = new BasketDomain(Guid.NewGuid(), Guid.NewGuid(), basketItemDomainList);

            // Act
            basketDomain.RemoveItemByProductId(basketItemDomain2.ProductId);

            // Assert
            basketDomain.Items.Should().HaveCount(1);
            basketDomain.Items.Should().Contain(basketItemDomain1);
        }

        [Fact]
        public void RemoveItemByProductId_WhenNotExists_ShouldDoNothing()
        {
            // Arrange
            var basketItemDomain1 = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), 0);
            var basketItemDomainList = new List<BasketItemDomain>()
            {
                basketItemDomain1
            };
            var basketDomain = new BasketDomain(Guid.NewGuid(), Guid.NewGuid(), basketItemDomainList);

            // Act
            basketDomain.RemoveItemByProductId(Guid.NewGuid());

            // Assert
            basketDomain.Items.Should().HaveCount(1);
            basketDomain.Items.Should().Contain(basketItemDomain1);
        }
    }
}
