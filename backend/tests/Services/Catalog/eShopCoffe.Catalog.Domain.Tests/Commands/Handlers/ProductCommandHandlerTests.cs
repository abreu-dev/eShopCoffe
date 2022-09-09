using eShopCoffe.Catalog.Domain.Commands.Handlers;
using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Domain.Repositories;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Catalog.Domain.Tests.Commands.Handlers
{
    public class ProductCommandHandlerTests
    {
        private static readonly Guid ValidId = Guid.NewGuid();
        private static readonly string ValidName = "Name";
        private static readonly string ValidDescription = "Description";
        private static readonly int ValidQuantityAvailable = 0;

        private readonly IBus _bus;
        private readonly IProductRepository _productRepository;
        private readonly ProductCommandHandler _handler;

        public ProductCommandHandlerTests()
        {
            _bus = Substitute.For<IBus>();
            _productRepository = Substitute.For<IProductRepository>();
            _handler = new ProductCommandHandler(_bus, _productRepository);
        }

        [Fact]
        public void Handle_AddProductCommand_WhenValidCommand_ShouldAdd()
        {
            // Arrange
            var command = new AddProductCommand(ValidName, ValidDescription, ValidQuantityAvailable);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _productRepository.Received(1).Add(Arg.Any<ProductDomain>());
            _productRepository.Received(1).Add(Arg.Is<ProductDomain>(x => x.Name == command.Name && x.Description == command.Description && x.QuantityAvailable == command.QuantityAvailable));
            _productRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_AddProductCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new AddProductCommand(string.Empty, ValidDescription, ValidQuantityAvailable);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Name' must not be empty."));

            _productRepository.DidNotReceive().Add(Arg.Any<ProductDomain>());
            _productRepository.UnitOfWork.DidNotReceive().Complete();
        }

        [Fact]
        public void Handle_UpdateProductCommand_WhenValidCommand_ShouldUpdate()
        {
            // Arrange
            var command = new UpdateProductCommand(ValidId, ValidName, ValidDescription, ValidQuantityAvailable);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _productRepository.Received(1).Update(Arg.Any<ProductDomain>());
            _productRepository.Received(1).Update(Arg.Is<ProductDomain>(x => x.Id == command.Id && x.Name == command.Name && x.Description == command.Description && x.QuantityAvailable == command.QuantityAvailable));
            _productRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_UpdateProductCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new UpdateProductCommand(ValidId, string.Empty, ValidDescription, ValidQuantityAvailable);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Name' must not be empty."));

            _productRepository.DidNotReceive().Update(Arg.Any<ProductDomain>());
            _productRepository.UnitOfWork.DidNotReceive().Complete();
        }

        [Fact]
        public void Handle_RemoveProductCommand_WhenValidCommand_ShouldDelete()
        {
            // Arrange
            var command = new RemoveProductCommand(ValidId);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _productRepository.Received(1).Delete(Arg.Any<Guid>());
            _productRepository.Received(1).Delete(Arg.Is<Guid>(x => x == command.Id));
            _productRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_RemoveProductCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new RemoveProductCommand(Guid.Empty);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Id' must not be empty."));

            _productRepository.DidNotReceive().Delete(Arg.Any<Guid>());
            _productRepository.UnitOfWork.DidNotReceive().Complete();
        }
    }
}
