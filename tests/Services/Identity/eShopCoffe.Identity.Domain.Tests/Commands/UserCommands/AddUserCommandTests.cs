using eShopCoffe.Identity.Domain.Commands.UserCommands;

namespace eShopCoffe.Identity.Domain.Tests.Commands.UserCommands
{
    public class AddUserCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var login = "Login";
            var password = "Password";

            // Act
            var command = new AddUserCommand(login, password);

            // Assert
            command.Login.Should().Be(login);
            command.Password.Should().Be(password);
        }
    }
}
