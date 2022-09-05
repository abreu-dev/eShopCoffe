using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Domain.Tests.Entities
{
    public class UserDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange
            var login = "Login";
            var password = "Password";

            // Act
            var userDomain = new UserDomain(login, password);

            // Assert
            userDomain.Login.Should().Be(login);
            userDomain.Password.Should().Be(password);
            userDomain.IsAdmin.Should().BeFalse();
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var login = "Login";
            var password = "Password";

            // Act
            var userDomain = new UserDomain(id, login, password);

            // Assert
            userDomain.Id.Should().Be(id);
            userDomain.Login.Should().Be(login);
            userDomain.Password.Should().Be(password);
            userDomain.IsAdmin.Should().BeFalse();
        }

        [Fact]
        public void Constructor3_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var login = "Login";
            var password = "Password";
            var isAdmin = true;

            // Act
            var userDomain = new UserDomain(id, login, password, isAdmin);

            // Assert
            userDomain.Id.Should().Be(id);
            userDomain.Login.Should().Be(login);
            userDomain.Password.Should().Be(password);
            userDomain.IsAdmin.Should().Be(isAdmin);
        }
    }
}
