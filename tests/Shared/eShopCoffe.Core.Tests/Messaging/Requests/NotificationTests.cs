using eShopCoffe.Core.Messaging.Requests;

namespace eShopCoffe.Core.Tests.Messaging.Requests
{
    public class NotificationTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var key = "Key";
            var value = "Value";

            // Act
            var domainNotification = new Notification(key, value);

            // Assert
            domainNotification.Key.Should().Be(key);
            domainNotification.Value.Should().Be(value);
        }
    }
}
