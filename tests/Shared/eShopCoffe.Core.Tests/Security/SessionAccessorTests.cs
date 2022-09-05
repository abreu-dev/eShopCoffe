using eShopCoffe.Core.Security;
using eShopCoffe.Core.Security.Interfaces;

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
    }
}
