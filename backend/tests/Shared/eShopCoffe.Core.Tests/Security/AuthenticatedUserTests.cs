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
            var login = "Login";
            var isAdmin = true;

            // Act
            var domainNotification = new AuthenticatedUser(id, login, isAdmin);

            // Assert
            domainNotification.Id.Should().Be(id);
            domainNotification.Login.Should().Be(login);
            domainNotification.IsAdmin.Should().Be(isAdmin);
        }
    }
}
