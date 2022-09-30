using eShopCoffe.Identity.Domain.Commands.UserCommands;

namespace eShopCoffe.Identity.Domain.Tests.Commands.UserCommands
{
    public class UpdateUserCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var username = "Username";
            var email = "Email";
            var password = "Password";

            // Act
            var command = new UpdateUserCommand(id, username, email, password);

            // Assert
            command.Id.Should().Be(id);
            command.Username.Should().Be(username);
            command.Email.Should().Be(email);
            command.Password.Should().Be(password);
        }
    }
}
