using eShopCoffe.Core.Messaging.Handlers;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using eShopCoffe.Core.Tests.Utils;

namespace eShopCoffe.Core.Tests.Messaging.Handlers
{
    public class NotificationHandlerTests
    {
        private readonly NotificationHandler _handler;

        public NotificationHandlerTests()
        {
            _handler = new NotificationHandler();
        }

        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Assert
            var notifications = PrivateObjectUtil.GetProperty(_handler, "_notifications") as List<INotification>;
            notifications.Should().BeEmpty();
        }

        [Fact]
        public void HasNotifications_WhenEmptyList_ShouldReturnFalse()
        {
            // Arrange
            var notifications = new List<INotification>();
            PrivateObjectUtil.SetProperty(_handler, "_notifications", notifications);

            // Act & Assert
            _handler.HasNotifications.Should().BeFalse();
        }

        [Fact]
        public void HasNotifications_WhenNotEmptyList_ShouldReturnTrue()
        {
            // Arrange
            var notifications = new List<INotification>()
            {
                Substitute.For<INotification>()
            };
            PrivateObjectUtil.SetProperty(_handler, "_notifications", notifications);

            // Act & Assert
            _handler.HasNotifications.Should().BeTrue();
        }

        [Fact]
        public void GetNotifications_ShouldReturnList()
        {
            // Arrange
            var expected = new List<INotification>()
            {
                Substitute.For<INotification>()
            };
            PrivateObjectUtil.SetProperty(_handler, "_notifications", expected);

            // Act
            var actual = _handler.GetNotifications();

            // Assert
            actual.Should().BeSameAs(expected);
        }

        [Fact]
        public void Handle_ShouldAddNotificationToList()
        {
            // Arrange
            PrivateObjectUtil.SetProperty(_handler, "_notifications", new List<INotification>());
            var mockNotification = Substitute.For<INotification>();

            // Act
            _handler.Handle(mockNotification);

            // Assert
            var notifications = PrivateObjectUtil.GetProperty(_handler, "_notifications") as List<INotification>;
            notifications.Should().HaveCount(1);
            notifications.Should().Contain(mockNotification);
        }
    }
}
