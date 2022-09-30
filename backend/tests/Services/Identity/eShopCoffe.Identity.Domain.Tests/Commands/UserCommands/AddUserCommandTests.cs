using eShopCoffe.Identity.Domain.Commands.UserCommands;

namespace eShopCoffe.Identity.Domain.Tests.Commands.UserCommands
{
    public class AddUserCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var username = "Username";
            var email = "Email";
            var password = "Password";

            // Act
            var command = new AddUserCommand(username, email, password);

            // Assert
            command.Username.Should().Be(username);
            command.Password.Should().Be(password);
        }
    }
}
