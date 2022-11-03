using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Domain.Enums;

namespace eShopCoffe.Ordering.Domain.Tests.Entities
{
    public class OrderDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var address = new AddressDomain(string.Empty, string.Empty);
            var paymentMethod = PaymentMethod.DebitCard;

            // Act
            var orderDomain = new OrderDomain(userId, address, paymentMethod);

            // Assert
            orderDomain.UserId.Should().Be(userId);
            orderDomain.Address.Should().Be(address);
            orderDomain.PaymentMethod.Should().Be(paymentMethod);
            orderDomain.Currency.Value.Should().Be(0);
            orderDomain.Currency.Code.Should().BeEmpty();
            orderDomain.Items.Should().BeEmpty();
            orderDomain.Status.Should().Be(OrderStatus.Pending);
            orderDomain.Events.Should().HaveCount(1);
            orderDomain.Events.Should().Contain(x => x.Status == OrderStatus.Pending && x.Date != default);
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var address = new AddressDomain(string.Empty, string.Empty);
            var status = OrderStatus.InDeliveryRoute;
            var paymentMethod = PaymentMethod.DebitCard;
            var currency = new CurrencyDomain(0, string.Empty);
            var events = new List<OrderEventDomain>();
            var items = new List<OrderItemDomain>();

            // Act
            var orderDomain = new OrderDomain(id, userId, address, status, paymentMethod, currency, events, items);

            // Assert
            orderDomain.UserId.Should().Be(userId);
            orderDomain.Address.Should().Be(address);
            orderDomain.PaymentMethod.Should().Be(paymentMethod);
            orderDomain.Currency.Should().Be(currency);
            orderDomain.Events.Should().BeEquivalentTo(events);
            orderDomain.Items.Should().BeEquivalentTo(items);
        }

        [Fact]
        public void AddItem_ShouldDoExpected()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var address = new AddressDomain(string.Empty, string.Empty);
            var paymentMethod = PaymentMethod.DebitCard;
            var orderDomain = new OrderDomain(userId, address, paymentMethod);

            var productId = Guid.NewGuid();
            var amount = 2;
            var currency = new CurrencyDomain(15, "Code");

            // Act
            orderDomain.AddItem(productId, amount, currency);

            // Assert
            orderDomain.Currency.Value.Should().Be(amount * currency.Value);
            orderDomain.Currency.Code.Should().Be(currency.Code);
            orderDomain.Items.Should().HaveCount(1);
            orderDomain.Items.Should().Contain(x => x.ProductId == productId && x.Amount == amount && x.Currency == currency);
        }
    }
}
