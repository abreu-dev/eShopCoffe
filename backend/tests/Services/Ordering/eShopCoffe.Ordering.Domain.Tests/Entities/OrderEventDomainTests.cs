using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Domain.Enums;

namespace eShopCoffe.Ordering.Domain.Tests.Entities
{
    public class OrderEventDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var status = OrderStatus.Pending;
            var date = DateTime.MinValue;

            // Act
            var orderEventDomain = new OrderEventDomain(orderId, status, date);

            // Assert
            orderEventDomain.OrderId.Should().Be(orderId);
            orderEventDomain.Status.Should().Be(status);
            orderEventDomain.Date.Should().Be(date);
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var orderId = Guid.NewGuid();
            var status = OrderStatus.Pending;
            var date = DateTime.MinValue;

            // Act
            var orderEventDomain = new OrderEventDomain(id, orderId, status, date);

            // Assert
            orderEventDomain.Id.Should().Be(id);
            orderEventDomain.OrderId.Should().Be(orderId);
            orderEventDomain.Status.Should().Be(status);
            orderEventDomain.Date.Should().Be(date);
        }
    }
}
