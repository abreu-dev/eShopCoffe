using eShopCoffe.Core.Exceptions;

namespace eShopCoffe.Core.Tests.Exceptions
{
    public class EShopCoffeExceptionTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var message = "Message";

            // Act
            var exception = new EShopCoffeException(message);

            // Arrange
            exception.Message.Should().Be(message);
        }
    }
}
