using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Infra.Data.Adapters;
using eShopCoffe.Basket.Infra.Data.Entities;

namespace eShopCoffe.Basket.Infra.Data.Tests.Adapters
{
    public class BasketItemDataAdapterTests
    {
        private readonly BasketItemDataAdapter _basketItemDataAdapter;

        public BasketItemDataAdapterTests()
        {
            _basketItemDataAdapter = new BasketItemDataAdapter();
        }

        [Fact]
        public void Transform_DomainToData_WhenNull_ShouldReturnNull()
        {
            // Arrange
            BasketItemDomain? domain = null;

            // Act
            var data = _basketItemDataAdapter.Transform(domain);

            // Assert
            data.Should().BeNull();
        }

        [Fact]
        public void Transform_DomainToData_WhenNotNull_ShouldReturnData()
        {
            // Arrange
            var domain = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), 1);

            // Act
            var data = _basketItemDataAdapter.Transform(domain);

            // Assert
            data.Should().NotBeNull();
            if (data == null) return;

            data.Id.Should().Be(domain.Id);
            data.ProductId.Should().Be(domain.ProductId);
            data.BasketId.Should().Be(domain.BasketId);
            data.Amount.Should().Be(domain.Amount);
        }

        [Fact]
        public void Transform_DataToDomain_WhenNull_ShouldReturnNull()
        {
            // Arrange
            BasketItemData? data = null;

            // Act
            var domain = _basketItemDataAdapter.Transform(data);

            // Assert
            domain.Should().BeNull();
        }

        [Fact]
        public void Transform_DataToDomain_WhenNotNull_ShouldReturnDomain()
        {
            // Arrange
            var data = new BasketItemData()
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                BasketId = Guid.NewGuid(),
                Amount = 1
            };

            // Act
            var domain = _basketItemDataAdapter.Transform(data);

            // Assert
            domain.Should().NotBeNull();
            if (domain == null) return;

            domain.Id.Should().Be(data.Id);
            domain.ProductId.Should().Be(data.ProductId);
            domain.BasketId.Should().Be(data.BasketId);
            domain.Amount.Should().Be(data.Amount);
        }
    }
}
