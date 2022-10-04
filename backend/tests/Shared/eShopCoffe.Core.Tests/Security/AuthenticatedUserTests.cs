using eShopCoffe.Core.Security;

namespace eShopCoffe.Core.Tests.Security
{
    public class AuthenticatedUserTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var username = "Username";
            var isAdmin = true;

            // Act
            var domainNotification = new AuthenticatedUser(id, username, isAdmin);

            // Assert
            domainNotification.Id.Should().Be(id);
            domainNotification.Username.Should().Be(username);
            domainNotification.IsAdmin.Should().Be(isAdmin);
        }
    }
}
