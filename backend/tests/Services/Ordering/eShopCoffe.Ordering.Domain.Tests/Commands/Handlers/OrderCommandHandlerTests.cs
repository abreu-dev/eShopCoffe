using eShopCoffe.Basket.Domain.Events.BasketEvents;
using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Domain.Repositories;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Ordering.Domain.Commands.Handlers;
using eShopCoffe.Ordering.Domain.Commands.OrderCommands;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Domain.Enums;
using eShopCoffe.Ordering.Domain.Repositories;

namespace eShopCoffe.Ordering.Domain.Tests.Commands.Handlers
{
    public class OrderCommandHandlerTests
    {
        private static readonly string ValidCep = "Cep";
        private static readonly string ValidNumber = "Number";
        private static readonly string ValidPaymentMethod = "Credit Card";
        private static readonly IEnumerable<AddOrderCommand.OrderItem> ValidItems = new List<AddOrderCommand.OrderItem>()
        {
            new AddOrderCommand.OrderItem(Guid.NewGuid(), 1)
        };
        private static readonly bool ValidClearBasket = true;

        private readonly IBus _bus;
        private readonly ISessionAccessor _sessionAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly OrderCommandHandler _orderCommandHandler;

        public OrderCommandHandlerTests()
        {
            _bus = Substitute.For<IBus>();
            _sessionAccessor = Substitute.For<ISessionAccessor>();
            _productRepository = Substitute.For<IProductRepository>();
            _orderRepository = Substitute.For<IOrderRepository>();
            _orderCommandHandler = new OrderCommandHandler(_bus, _sessionAccessor, _productRepository, _orderRepository);
        }

        [Fact]
        public void Handle_AddOrderCommand_WhenValidCommand_ShouldAdd()
        {
            // Arrange
            var command = new AddOrderCommand(ValidCep, ValidNumber, ValidPaymentMethod, ValidItems, false);

            var userId = Guid.NewGuid();
            _sessionAccessor.UserId.Returns(userId);

            var product = new ProductDomain(string.Empty, string.Empty, string.Empty, 15, new CurrencyDomain(15, "Code"));
            _productRepository.GetById(command.Items.First().ProductId).Returns(product);

            // Act
            _orderCommandHandler.Handle(command).Wait();

            // Assert
            _orderRepository.Received(1).Add(Arg.Any<OrderDomain>());
            _orderRepository.Received(1).Add(Arg.Is<OrderDomain>(x => x.UserId == userId
                && x.Address.Cep == command.Cep
                && x.Address.Number == command.Number
                && x.PaymentMethod == PaymentMethod.CreditCard
                && x.Items.Count == 1
                && x.Items.ElementAt(0).ProductId == command.Items.First().ProductId
                && x.Items.ElementAt(0).Amount == command.Items.First().Amount
                && x.Items.ElementAt(0).Currency == product.Currency));
            _orderRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());

            _bus.DidNotReceive().Event(Arg.Any<ClearBasketEvent>());
        }

        [Fact]
        public void Handle_AddOrderCommand_WhenValidCommand_ShouldAddAndRaiseEvent()
        {
            // Arrange
            var command = new AddOrderCommand(ValidCep, ValidNumber, ValidPaymentMethod, ValidItems, true);

            var userId = Guid.NewGuid();
            _sessionAccessor.UserId.Returns(userId);

            var product = new ProductDomain(string.Empty, string.Empty, string.Empty, 15, new CurrencyDomain(15, "Code"));
            _productRepository.GetById(command.Items.First().ProductId).Returns(product);

            // Act
            _orderCommandHandler.Handle(command).Wait();

            // Assert
            _orderRepository.Received(1).Add(Arg.Any<OrderDomain>());
            _orderRepository.Received(1).Add(Arg.Is<OrderDomain>(x => x.UserId == userId
                && x.Address.Cep == command.Cep
                && x.Address.Number == command.Number
                && x.PaymentMethod == PaymentMethod.CreditCard
                && x.Items.Count == 1
                && x.Items.ElementAt(0).ProductId == command.Items.First().ProductId
                && x.Items.ElementAt(0).Amount == command.Items.First().Amount
                && x.Items.ElementAt(0).Currency == product.Currency));
            _orderRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());

            _bus.Received(1).Event(Arg.Any<ClearBasketEvent>());
            _bus.Received(1).Event(Arg.Is<ClearBasketEvent>(x => x.UserId == userId));
        }

        [Fact]
        public void Handle_AddOrderCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new AddOrderCommand(string.Empty, ValidNumber, ValidPaymentMethod, ValidItems, ValidClearBasket);

            // Act
            _orderCommandHandler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Cep' must not be empty."));

            _orderRepository.DidNotReceive().Add(Arg.Any<OrderDomain>());
            _orderRepository.UnitOfWork.DidNotReceive().Complete();
            _bus.DidNotReceive().Event(Arg.Any<ClearBasketEvent>());
        }
    }
}
