using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Domain.Enums;
using eShopCoffe.Ordering.Infra.Data.Adapters;
using eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Tests.Adapters
{
    public class OrderDataAdapterTests
    {
        private readonly IOrderItemDataAdapter _orderItemDataAdapter;
        private readonly IOrderEventDataAdapter _orderEventDataAdapter;
        private readonly OrderDataAdapter _orderDataAdapter;

        public OrderDataAdapterTests()
        {
            _orderItemDataAdapter = Substitute.For<IOrderItemDataAdapter>();
            _orderEventDataAdapter = Substitute.For<IOrderEventDataAdapter>();
            _orderDataAdapter = new OrderDataAdapter(_orderItemDataAdapter, _orderEventDataAdapter);
        }

        [Fact]
        public void Transform_DomainToData_WhenNull_ShouldReturnNull()
        {
            // Arrange
            OrderDomain? domain = null;

            // Act
            var data = _orderDataAdapter.Transform(domain);

            // Assert
            data.Should().BeNull();
        }

        [Fact]
        public void Transform_DomainToData_WhenNotNull_ShouldReturnData()
        {
            // Arrange
            var domainItems = new List<OrderItemDomain>();
            var domainEvents = new List<OrderEventDomain>();
            var domain = new OrderDomain(
                Guid.NewGuid(),
                Guid.NewGuid(),
                new AddressDomain("Cep", "Number"),
                OrderStatus.Pending,
                PaymentMethod.CreditCard,
                new CurrencyDomain(1, "Code"),
                domainEvents,
                domainItems);

            var dataItems = new List<OrderItemData>();
            _orderItemDataAdapter.Transform(domainItems).Returns(dataItems);

            var dataEvents = new List<OrderEventData>();
            _orderEventDataAdapter.Transform(domainEvents).Returns(dataEvents);

            // Act
            var data = _orderDataAdapter.Transform(domain);

            // Assert
            data.Should().NotBeNull();
            if (data == null) return;

            data.Id.Should().Be(domain.Id);
            data.UserId.Should().Be(domain.UserId);
            data.Cep.Should().Be(domain.Address.Cep);
            data.Number.Should().Be(domain.Address.Number);
            data.Status.Should().Be(domain.Status);
            data.PaymentMethod.Should().Be(domain.PaymentMethod);
            data.CurrencyValue.Should().Be(domain.Currency.Value);
            data.CurrencyCode.Should().Be(domain.Currency.Code);
            data.Items.Should().BeEquivalentTo(dataItems);
            data.Events.Should().BeEquivalentTo(dataEvents);
        }

        [Fact]
        public void Transform_DataToDomain_WhenNull_ShouldReturnNull()
        {
            // Arrange
            OrderData? data = null;

            // Act
            var domain = _orderDataAdapter.Transform(data);

            // Assert
            domain.Should().BeNull();
        }

        [Fact]
        public void Transform_DataToDomain_WhenNotNull_ShouldReturnDomain()
        {
            // Arrange
            var dataItems = new List<OrderItemData>();
            var dataEvents = new List<OrderEventData>();
            var data = new OrderData()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Cep = "Cep",
                Number = "Number",
                Status = OrderStatus.Pending,
                PaymentMethod = PaymentMethod.CreditCard,
                CurrencyCode = "Code",
                CurrencyValue = 10,
                Items = dataItems,
                Events = dataEvents
            };

            var domainItems = new List<OrderItemDomain>();
            _orderItemDataAdapter.Transform(dataItems).Returns(domainItems);

            var domainEvents = new List<OrderEventDomain>();
            _orderEventDataAdapter.Transform(dataEvents).Returns(domainEvents);

            // Act
            var domain = _orderDataAdapter.Transform(data);

            // Assert
            domain.Should().NotBeNull();
            if (domain == null) return;

            domain.Id.Should().Be(data.Id);
            domain.UserId.Should().Be(data.UserId);
            domain.Address.Cep.Should().Be(data.Cep);
            domain.Address.Number.Should().Be(data.Number);
            domain.Status.Should().Be(data.Status);
            domain.PaymentMethod.Should().Be(data.PaymentMethod);
            domain.Currency.Value.Should().Be(data.CurrencyValue);
            domain.Currency.Code.Should().Be(data.CurrencyCode);
            domain.Items.Should().BeEquivalentTo(domainItems);
            domain.Events.Should().BeEquivalentTo(domainEvents);
        }
    }
}
