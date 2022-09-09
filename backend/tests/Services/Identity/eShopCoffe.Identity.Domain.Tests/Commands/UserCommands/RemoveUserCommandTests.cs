using eShopCoffe.Identity.Domain.Commands.UserCommands;

namespace eShopCoffe.Identity.Domain.Tests.Commands.UserCommands
{
    public class RemoveUserCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var command = new RemoveUserCommand(id);

            // Assert
            command.Id.Should().Be(id);
        }
    }
}
