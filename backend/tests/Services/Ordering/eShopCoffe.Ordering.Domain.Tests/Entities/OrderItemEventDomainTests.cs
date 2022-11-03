using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Ordering.Domain.Entities;

namespace eShopCoffe.Ordering.Domain.Tests.Entities
{
    public class OrderItemDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var amount = 0;
            var currency = new CurrencyDomain(0, string.Empty);

            // Act
            var orderItemDomain = new OrderItemDomain(productId, orderId, amount, currency);

            // Assert
            orderItemDomain.OrderId.Should().Be(orderId);
            orderItemDomain.ProductId.Should().Be(productId);
            orderItemDomain.Amount.Should().Be(amount);
            orderItemDomain.Currency.Should().Be(currency);
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var orderId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var amount = 0;
            var currency = new CurrencyDomain(0, string.Empty);

            // Act
            var orderItemDomain = new OrderItemDomain(id, productId, orderId, amount, currency);

            // Assert
            orderItemDomain.Id.Should().Be(id);
            orderItemDomain.OrderId.Should().Be(orderId);
            orderItemDomain.ProductId.Should().Be(productId);
            orderItemDomain.Amount.Should().Be(amount);
            orderItemDomain.Currency.Should().Be(currency);
        }

        [Fact]
        public void GetValue_ShouldReturnExpected()
        {
            // Arrange
            var id = Guid.NewGuid();
            var orderId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var amount = 2;
            var currency = new CurrencyDomain(15, string.Empty);
            var orderItemDomain = new OrderItemDomain(id, orderId, productId, amount, currency);

            // Act
            var value = orderItemDomain.GetValue();

            // Assert
            value.Should().Be(amount * currency.Value);
        }
    }
}
