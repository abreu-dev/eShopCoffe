using eShopCoffe.Core.Cryptography.Interfaces;
using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Domain.Tests.Entities
{
    public class UserDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange
            var username = "Username";
            var email = "Email";

            // Act
            var userDomain = new UserDomain(username, email);

            // Assert
            userDomain.Username.Should().Be(username);
            userDomain.Email.Should().Be(email);
            userDomain.IsAdmin.Should().BeFalse();
            userDomain.HashedPassword.Should().BeEmpty();
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var username = "Username";
            var email = "Email";

            // Act
            var userDomain = new UserDomain(id, username, email);

            // Assert
            userDomain.Id.Should().Be(id);
            userDomain.Username.Should().Be(username);
            userDomain.Email.Should().Be(email);
            userDomain.IsAdmin.Should().BeFalse();
            userDomain.HashedPassword.Should().BeEmpty();
        }

        [Fact]
        public void Constructor3_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var username = "Username";
            var email = "Email";
            var isAdmin = true;

            // Act
            var userDomain = new UserDomain(id, username, email, isAdmin);

            // Assert
            userDomain.Id.Should().Be(id);
            userDomain.Username.Should().Be(username);
            userDomain.Email.Should().Be(email);
            userDomain.IsAdmin.Should().Be(isAdmin);
            userDomain.HashedPassword.Should().BeEmpty();
        }

        [Fact]
        public void SetPassword_ShouldSetHashedPassword()
        {
            // Arrange
            var userDomain = new UserDomain("Username", "Email");

            var password = "Password";

            var hashedPassword = "HashedPassword";
            var passwordHash = Substitute.For<IPasswordHash>();
            passwordHash.Hash(password).Returns(hashedPassword);

            // Act
            userDomain.SetPassword(passwordHash, password);

            // Assert
            passwordHash.Received(1).Hash(Arg.Any<string>());
            passwordHash.Received(1).Hash(password);

            userDomain.HashedPassword.Should().Be(hashedPassword);
        }
    }
}
