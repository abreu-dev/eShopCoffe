using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using eShopCoffe.Identity.Domain.Commands.Handlers;
using eShopCoffe.Identity.Domain.Commands.UserCommands;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Domain.Tests.Commands.Handlers
{
    public class UserCommandHandlerTests
    {
        private static readonly Guid ValidId = Guid.NewGuid();
        private static readonly string ValidLogin = "Login";
        private static readonly string ValidPassword = "Password";

        private readonly IBus _bus;
        private readonly IUserRepository _userRepository;
        private readonly UserCommandHandler _handler;

        public UserCommandHandlerTests()
        {
            _bus = Substitute.For<IBus>();
            _userRepository = Substitute.For<IUserRepository>();
            _handler = new UserCommandHandler(_bus, _userRepository);
        }

        [Fact]
        public void Handle_AddUserCommand_WhenValidCommand_ShouldAdd()
        {
            // Arrange
            var command = new AddUserCommand(ValidLogin, ValidPassword);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _userRepository.Received(1).Add(Arg.Any<UserDomain>());
            _userRepository.Received(1).Add(Arg.Is<UserDomain>(x => x.Login == command.Login && x.Password == command.Password));
            _userRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_AddUserCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new AddUserCommand(string.Empty, ValidPassword);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Login' must not be empty."));

            _userRepository.DidNotReceive().Add(Arg.Any<UserDomain>());
            _userRepository.UnitOfWork.DidNotReceive().Complete();
        }

        [Fact]
        public void Handle_UpdateUserCommand_WhenValidCommand_ShouldUpdate()
        {
            // Arrange
            var command = new UpdateUserCommand(ValidId, ValidLogin, ValidPassword);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _userRepository.Received(1).Update(Arg.Any<UserDomain>());
            _userRepository.Received(1).Update(Arg.Is<UserDomain>(x => x.Id == command.Id && x.Login == command.Login && x.Password == command.Password));
            _userRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_UpdateUserCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new UpdateUserCommand(ValidId, string.Empty, ValidPassword);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Login' must not be empty."));

            _userRepository.DidNotReceive().Update(Arg.Any<UserDomain>());
            _userRepository.UnitOfWork.DidNotReceive().Complete();
        }

        [Fact]
        public void Handle_RemoveUserCommand_WhenValidCommand_ShouldDelete()
        {
            // Arrange
            var command = new RemoveUserCommand(ValidId);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _userRepository.Received(1).Delete(Arg.Any<Guid>());
            _userRepository.Received(1).Delete(Arg.Is<Guid>(x => x == command.Id));
            _userRepository.UnitOfWork.Received(1).Complete();

            _bus.DidNotReceive().Notification(Arg.Any<INotification>());
        }

        [Fact]
        public void Handle_RemoveUserCommand_WhenInvalidCommand_ShouldNotificate()
        {
            // Arrange
            var command = new RemoveUserCommand(Guid.Empty);

            // Act
            _handler.Handle(command).Wait();

            // Assert
            _bus.Received(1).Notification(Arg.Any<INotification>());
            _bus.Received(1).Notification(Arg.Is<INotification>(x => x.Key == "NotEmptyValidator" && x.Value == "'Id' must not be empty."));

            _userRepository.DidNotReceive().Delete(Arg.Any<Guid>());
            _userRepository.UnitOfWork.DidNotReceive().Complete();
        }
    }
}
