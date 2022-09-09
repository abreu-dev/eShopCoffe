using eShopCoffe.Identity.Application.Services;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Application.Tests.Services
{
    public class AuthenticationServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationService _authenticationService;

        public AuthenticationServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _authenticationService = new AuthenticationService(_userRepository);
        }

        [Fact]
        public void Authenticate_ShouldBeSuccess_WhenFoundUser()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Login", "Password");
            _userRepository.GetByLoginAndPassword(userDomain.Login, userDomain.Password).Returns(userDomain);

            // Act
            var result = _authenticationService.Authenticate(userDomain.Login, userDomain.Password);

            // Assert
            result.HasSucceed.Should().BeTrue();
            result.Item.Should().Be(userDomain);
        }

        [Fact]
        public void Authenticate_ShouldBeFailure_WhenNotFoundUser()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Login", "Password");
            _userRepository.GetByLoginAndPassword(userDomain.Login, userDomain.Password).Returns(userDomain);

            // Act
            var result = _authenticationService.Authenticate("Login1", "Password1");

            // Assert
            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("LoginFailed");
            result.ErrorMessage.Should().Be("Incorrect username or password.");
        }
    }
}
