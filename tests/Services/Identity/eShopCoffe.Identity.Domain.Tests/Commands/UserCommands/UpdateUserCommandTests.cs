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
            var login = "Login";
            var password = "Password";

            // Act
            var command = new UpdateUserCommand(id, login, password);

            // Assert
            command.Id.Should().Be(id);
            command.Login.Should().Be(login);
            command.Password.Should().Be(password);
        }
    }
}
