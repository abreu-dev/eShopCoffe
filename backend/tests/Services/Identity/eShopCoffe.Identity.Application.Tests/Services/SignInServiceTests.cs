using eShopCoffe.Identity.Application.Services;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Application.Tests.Services
{
    public class SignInServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInService _signInService;

        public SignInServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _signInService = new SignInService(_userRepository);
        }

        [Fact]
        public void SignIn_ShouldBeSuccess_WhenFoundUser()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Username", "Email");
            var password = "Password";
            _userRepository.GetByUsernameAndPassword(userDomain.Username, password).Returns(userDomain);

            // Act
            var result = _signInService.SignIn(userDomain.Username, password);

            // Assert
            result.HasSucceed.Should().BeTrue();
            result.Item.Should().Be(userDomain);
        }

        [Fact]
        public void SignIn_ShouldBeFailure_WhenNotFoundUser()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Username", "Email");
            var password = "Password";
            _userRepository.GetByUsernameAndPassword(userDomain.Username, password).Returns(userDomain);

            // Act
            var result = _signInService.SignIn("Username1", "Password1");

            // Assert
            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("SignInFailed");
            result.ErrorMessage.Should().Be("Incorrect username or password.");
        }
    }
}
