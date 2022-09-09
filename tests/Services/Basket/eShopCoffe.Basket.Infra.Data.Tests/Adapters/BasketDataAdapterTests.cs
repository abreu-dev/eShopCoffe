using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Infra.Data.Adapters;
using eShopCoffe.Basket.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Basket.Infra.Data.Entities;

namespace eShopCoffe.Basket.Infra.Data.Tests.Adapters
{
    public class BasketDataAdapterTests
    {
        private readonly IBasketItemDataAdapter _basketItemDataAdapter;
        private readonly BasketDataAdapter _basketDataAdapter;

        public BasketDataAdapterTests()
        {
            _basketItemDataAdapter = Substitute.For<IBasketItemDataAdapter>();
            _basketDataAdapter = new BasketDataAdapter(_basketItemDataAdapter);
        }

        [Fact]
        public void Transform_DomainToData_WhenNull_ShouldReturnNull()
        {
            // Arrange
            BasketDomain? domain = null;

            // Act
            var data = _basketDataAdapter.Transform(domain);

            // Assert
            data.Should().BeNull();
        }

        [Fact]
        public void Transform_DomainToData_WhenNotNull_ShouldReturnData()
        {
            // Arrange
            var domainItems = new List<BasketItemDomain>();
            var domain = new BasketDomain(Guid.NewGuid(), Guid.NewGuid(), domainItems);

            var dataItems = new List<BasketItemData>();
            _basketItemDataAdapter.Transform(domainItems).Returns(dataItems);

            // Act
            var data = _basketDataAdapter.Transform(domain);

            // Assert
            data.Should().NotBeNull();
            if (data == null) return;

            data.Id.Should().Be(domain.Id);
            data.UserId.Should().Be(domain.UserId);
            data.Items.Should().BeEquivalentTo(dataItems);
        }

        [Fact]
        public void Transform_DataToDomain_WhenNull_ShouldReturnNull()
        {
            // Arrange
            BasketData? data = null;

            // Act
            var domain = _basketDataAdapter.Transform(data);

            // Assert
            domain.Should().BeNull();
        }

        [Fact]
        public void Transform_DataToDomain_WhenNotNull_ShouldReturnDomain()
        {
            // Arrange
            var dataItems = new List<BasketItemData>();
            var data = new BasketData()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Items = dataItems
            };

            var domainItems = new List<BasketItemDomain>();
            _basketItemDataAdapter.Transform(dataItems).Returns(domainItems);

            // Act
            var domain = _basketDataAdapter.Transform(data);

            // Assert
            domain.Should().NotBeNull();
            if (domain == null) return;

            domain.Id.Should().Be(data.Id);
            domain.UserId.Should().Be(data.UserId);
            domain.Items.Should().BeEquivalentTo(domainItems);
        }
    }
}
