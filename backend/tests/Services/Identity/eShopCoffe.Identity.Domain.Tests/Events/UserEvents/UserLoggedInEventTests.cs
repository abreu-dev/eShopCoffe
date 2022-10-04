using eShopCoffe.Identity.Domain.Events.UserEvents;

namespace eShopCoffe.Identity.Domain.Tests.Events.UserEvents
{
    public class UserLoggedInEventTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var userId = Guid.NewGuid();

            // Act
            var @event = new UserSignedInEvent(userId);

            // Assert
            @event.UserId.Should().Be(userId);
        }
    }
}
