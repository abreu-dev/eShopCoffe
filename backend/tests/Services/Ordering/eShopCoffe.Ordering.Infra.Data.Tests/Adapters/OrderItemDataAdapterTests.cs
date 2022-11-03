using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Infra.Data.Adapters;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Tests.Adapters
{
    public class OrderItemDataAdapterTests
    {
        private readonly OrderItemDataAdapter _orderItemDataAdapter;

        public OrderItemDataAdapterTests()
        {
            _orderItemDataAdapter = new OrderItemDataAdapter();
        }

        [Fact]
        public void Transform_DomainToData_WhenNull_ShouldReturnNull()
        {
            // Arrange
            OrderItemDomain? domain = null;

            // Act
            var data = _orderItemDataAdapter.Transform(domain);

            // Assert
            data.Should().BeNull();
        }

        [Fact]
        public void Transform_DomainToData_WhenNotNull_ShouldReturnData()
        {
            // Arrange
            var domain = new OrderItemDomain(Guid.NewGuid(), Guid.NewGuid(), 1, new CurrencyDomain(1, "Code"));

            // Act
            var data = _orderItemDataAdapter.Transform(domain);

            // Assert
            data.Should().NotBeNull();
            if (data == null) return;

            data.Id.Should().Be(domain.Id);
            data.ProductId.Should().Be(domain.ProductId);
            data.OrderId.Should().Be(domain.OrderId);
            data.Amount.Should().Be(domain.Amount);
            data.CurrencyCode.Should().Be(domain.Currency.Code);
            data.CurrencyValue.Should().Be(domain.Currency.Value);
        }

        [Fact]
        public void Transform_DataToDomain_WhenNull_ShouldReturnNull()
        {
            // Arrange
            OrderItemData? data = null;

            // Act
            var domain = _orderItemDataAdapter.Transform(data);

            // Assert
            domain.Should().BeNull();
        }

        [Fact]
        public void Transform_DataToDomain_WhenNotNull_ShouldReturnDomain()
        {
            // Arrange
            var data = new OrderItemData()
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                OrderId = Guid.NewGuid(),
                Amount = 1,
                CurrencyCode = "Code",
                CurrencyValue = 1
            };

            // Act
            var domain = _orderItemDataAdapter.Transform(data);

            // Assert
            domain.Should().NotBeNull();
            if (domain == null) return;

            domain.Id.Should().Be(data.Id);
            domain.ProductId.Should().Be(data.ProductId);
            domain.OrderId.Should().Be(data.OrderId);
            domain.Amount.Should().Be(data.Amount);
            domain.Currency.Code.Should().Be(data.CurrencyCode);
            domain.Currency.Value.Should().Be(data.CurrencyValue);
        }
    }
}
