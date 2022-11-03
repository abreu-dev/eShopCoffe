using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Domain.Enums;
using eShopCoffe.Ordering.Infra.Data.Adapters;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Tests.Adapters
{
    public class OrderEventDataAdapterTests
    {
        private readonly OrderEventDataAdapter _orderEventDataAdapter;

        public OrderEventDataAdapterTests()
        {
            _orderEventDataAdapter = new OrderEventDataAdapter();
        }

        [Fact]
        public void Transform_DomainToData_WhenNull_ShouldReturnNull()
        {
            // Arrange
            OrderEventDomain? domain = null;

            // Act
            var data = _orderEventDataAdapter.Transform(domain);

            // Assert
            data.Should().BeNull();
        }

        [Fact]
        public void Transform_DomainToData_WhenNotNull_ShouldReturnData()
        {
            // Arrange
            var domain = new OrderEventDomain(Guid.NewGuid(), OrderStatus.Pending, DateTime.MinValue);

            // Act
            var data = _orderEventDataAdapter.Transform(domain);

            // Assert
            data.Should().NotBeNull();
            if (data == null) return;

            data.Id.Should().Be(domain.Id);
            data.OrderId.Should().Be(domain.OrderId);
            data.Status.Should().Be(domain.Status);
            data.Date.Should().Be(domain.Date);
        }

        [Fact]
        public void Transform_DataToDomain_WhenNull_ShouldReturnNull()
        {
            // Arrange
            OrderEventData? data = null;

            // Act
            var domain = _orderEventDataAdapter.Transform(data);

            // Assert
            domain.Should().BeNull();
        }

        [Fact]
        public void Transform_DataToDomain_WhenNotNull_ShouldReturnDomain()
        {
            // Arrange
            var data = new OrderEventData()
            {
                Id = Guid.NewGuid(),
                OrderId = Guid.NewGuid(),
                Status = OrderStatus.Pending,
                Date = DateTime.MinValue
            };

            // Act
            var domain = _orderEventDataAdapter.Transform(data);

            // Assert
            domain.Should().NotBeNull();
            if (domain == null) return;

            domain.Id.Should().Be(data.Id);
            domain.OrderId.Should().Be(data.OrderId);
            domain.Status.Should().Be(data.Status);
            domain.Date.Should().Be(data.Date);
        }
    }
}
