using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Basket.Domain.Commands.Handlers;
using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Domain.Repositories;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using eShopCoffe.Core.Security.Interfaces;

namespace eShopCoffe.Basket.Domain.Tests.Commands.Handlers
{
    public class BasketCommandHandlerTests
    {
        private static readonly Guid ValidProductId = Guid.NewGuid();
        private static readonly int ValidAmount = 1;
        private static readonly bool ValidIncrease = true;

        private readonly IBus _bus;
        private readonly IBasketRepository _basketRepository;
        private readonly ISessionAccessor _sessionAccessor;
        private readonly BasketCommandHandler _basketCommandHandler;

        public BasketCommandHandlerTests()
        {
            _bus = Substitute.For<IBus>();
            _basketRepository = Substitute.For<IBasketRepository>();
            _sessionAccessor = Substitute.For<ISessionAccessor>();
            _basketCommandHandler = new BasketCommandHandler(_bus, _basketRepository, _sessionAccessor);
        }

        [Fact]
        public void Handle_AddOrUpdateBasketItemCommand_WhenValidCommandAndBasketNotExists_ShouldAdd()
        {
            // Arrange
            var command = new AddOrUpdateBasketItemCommand(ValidProductId, ValidAmount, ValidIncrease);

            var userId = Guid.NewGuid();
            _sessionAccessor.UserId.Returns(userId);

            _basketRepository.GetByUserId(userId).ReturnsNull();

            // Act
            _basketCommandHandler.Handle(command).Wait();

            // Assert
            _basketRepository.Received(1).Add(Arg.Any<BasketDomain>());
            _basketRepository.Received(1).Add(Arg.Is<BasketDomain>(x => x.UserId == userId && x.Items.Count == 1 &&
                 x.Items.ElementAt(0).ProductId == command.ProductId && x.Items.ElementAt(0).Amount == command.Amount));
            _basketRepository.UnitOfWork.Received(1).Complete();

            _basketRepository.DidNotReceive().Update(Arg.Any<BasketDomain>());
            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_AddOrUpdateBasketItemCommand_WhenValidCommandAndBasketExists_ShouldUpdate()
        {
            // Arrange
            var command = new AddOrUpdateBasketItemCommand(ValidProductId, ValidAmount, ValidIncrease);

            var userId = Guid.NewGuid();
            _sessionAccessor.UserId.Returns(userId);

            var basket = new BasketDomain(userId);
            _basketRepository.GetByUserId(userId).Returns(basket);

            // Act
            _basketCommandHandler.Handle(command).Wait();

            // Assert
            _basketRepository.Received(1).Update(Arg.Any<BasketDomain>());
            _basketRepository.Received(1).Update(Arg.Is<BasketDomain>(x => x.UserId == userId && x.Items.Count == 1 &&
                 x.Items.ElementAt(0).ProductId == command.ProductId && x.Items.ElementAt(0).Amount == command.Amount));
            _basketRepository.UnitOfWork.Received(1).Complete();

            _basketRepository.DidNotReceive().Add(Arg.Any<BasketDomain>());
            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_AddOrUpdateBasketItemCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new AddOrUpdateBasketItemCommand(Guid.Empty, ValidAmount, ValidIncrease);

            // Act
            _basketCommandHandler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Product Id' must not be empty."));

            _basketRepository.DidNotReceive().Add(Arg.Any<BasketDomain>());
            _basketRepository.DidNotReceive().Update(Arg.Any<BasketDomain>());
            _basketRepository.UnitOfWork.DidNotReceive().Complete();
        }

        [Fact]
        public void Handle_RemoveBasketItemCommand_WhenValidCommandAndBasketNotExists_ShouldDoNothing()
        {
            // Arrange
            var command = new RemoveBasketItemCommand(ValidProductId);

            var userId = Guid.NewGuid();
            _sessionAccessor.UserId.Returns(userId);
            _basketRepository.GetByUserId(userId).ReturnsNull();

            // Act
            _basketCommandHandler.Handle(command).Wait();

            // Assert
            _basketRepository.DidNotReceive().Update(Arg.Any<BasketDomain>());
            _basketRepository.UnitOfWork.DidNotReceive().Complete();
            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_RemoveBasketItemCommand_WhenValidCommandAndBasketExists_ShouldDelete()
        {
            // Arrange
            var command = new RemoveBasketItemCommand(ValidProductId);

            var userId = Guid.NewGuid();
            _sessionAccessor.UserId.Returns(userId);

            var item1 = new BasketItemDomain(Guid.NewGuid(), Guid.NewGuid(), 0);
            var item2 = new BasketItemDomain(ValidProductId, Guid.NewGuid(), 0);
            var items = new List<BasketItemDomain>()
            {
                item1, item2
            };
            var basket = new BasketDomain(Guid.NewGuid(), userId, items);
            _basketRepository.GetByUserId(userId).Returns(basket);

            // Act
            _basketCommandHandler.Handle(command).Wait();

            // Assert
            _basketRepository.Received(1).Update(Arg.Any<BasketDomain>());
            _basketRepository.Received(1).Update(Arg.Is<BasketDomain>(x => x.Items.Count == 1 && x.Items.ElementAt(0) == item1));
            _basketRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_RemoveBasketItemCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new RemoveBasketItemCommand(Guid.Empty);

            // Act
            _basketCommandHandler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Product Id' must not be empty."));

            _basketRepository.DidNotReceive().Update(Arg.Any<BasketDomain>());
            _basketRepository.UnitOfWork.DidNotReceive().Complete();
        }
    }
}
