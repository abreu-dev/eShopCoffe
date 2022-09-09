using eShopCoffe.Core.Exceptions;
using eShopCoffe.Core.Security;
using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Core.Tests.Utils;

namespace eShopCoffe.Core.Tests.Security
{
    public class SessionAccessorTests
    {
        private readonly ISessionAccessor _sessionAccessor;

        public SessionAccessorTests()
        {
            _sessionAccessor = new SessionAccessor();
        }

        [Fact]
        public void Authenticate_ShouldSetUser()
        {
            // Arrange
            var authenticatedUser = Substitute.For<IAuthenticatedUser>();

            // Act
            _sessionAccessor.Authenticate(authenticatedUser);

            // Assert
            _sessionAccessor.User.Should().Be(authenticatedUser);
        }

        [Fact]
        public void UserId_WhenDontHaveAuthenticatedUser_ShouldThrowException()
        {
            // Act & Assert
            var exception = Assert.Throws<EShopCoffeException>(() => _sessionAccessor.UserId);
            exception.Message.Should().Be("User must be authenticated.");
        }

        [Fact]
        public void UserId_WhenHaveAuthenticatedUser_ShouldReturnUserId()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var authenticatedUser = Substitute.For<IAuthenticatedUser>();
            authenticatedUser.Id.Returns(userId);
            _sessionAccessor.Authenticate(authenticatedUser);

            // Act & Assert
            _sessionAccessor.UserId.Should().Be(userId);
        }
    }
}
