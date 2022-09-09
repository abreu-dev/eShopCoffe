using eShopCoffe.Identity.Domain.Events.Handlers;
using eShopCoffe.Identity.Domain.Events.UserEvents;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Domain.Tests.Events.Handlers
{
    public class UserEventHandlerTests
    {
        private readonly IUserRepository _userRepository;
        private readonly UserEventHandler _handler;

        public UserEventHandlerTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _handler = new UserEventHandler(_userRepository);
        }

        [Fact]
        public void Handle_UserLoggedInEvent_ShouldCallUserLastAccess()
        {
            // Arrange
            var @event = new UserLoggedInEvent(Guid.NewGuid());

            // Act
            _handler.Handle(@event);

            // Assert
            _userRepository.Received(1).UpdateLastAccess(@event.UserId);
            _userRepository.UnitOfWork.Received(1).Complete();
        }
    }
}
