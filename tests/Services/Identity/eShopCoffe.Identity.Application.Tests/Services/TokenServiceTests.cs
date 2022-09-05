using eShopCoffe.Core.Security;
using eShopCoffe.Identity.Application.Services;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;
using Microsoft.Extensions.Options;

namespace eShopCoffe.Identity.Application.Tests.Services
{
    public class TokenServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppSettings> _appSettingsOptions;
        private readonly AppSettings _appSettings;
        private readonly TokenService _tokenService;

        public TokenServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _appSettingsOptions = Substitute.For<IOptions<AppSettings>>();
            _appSettings = new AppSettings();
            _appSettingsOptions.Value.Returns(_appSettings);

            _tokenService = new TokenService(_userRepository, _appSettingsOptions);
        }

        [Fact]
        public void GenerateAuthenticationToken_ShouldReturnToken()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Login", "Password");
            _appSettings.Expires = 120;
            _appSettings.Secret = Guid.NewGuid().ToString();

            // Act
            var result = _tokenService.GenerateAuthenticationToken(userDomain);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void ValidateToken_WhenEmptyToken_ShouldReturnNull()
        {
            // Arrange & Act
            var result = _tokenService.ValidateToken(string.Empty);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void ValidateToken_WhenUserNotFound_ShouldReturnNull()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Login", "Password");
            _appSettings.Expires = 120;
            _appSettings.Secret = Guid.NewGuid().ToString();
            var token = _tokenService.GenerateAuthenticationToken(userDomain);
            _userRepository.GetById(userDomain.Id).ReturnsNull();

            // Act
            var result = _tokenService.ValidateToken(token);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void ValidateToken_ShouldReturnAuthenticatedUser()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Login", "Password");
            _appSettings.Expires = 120;
            _appSettings.Secret = Guid.NewGuid().ToString();
            var token = _tokenService.GenerateAuthenticationToken(userDomain);
            _userRepository.GetById(userDomain.Id).Returns(userDomain);

            // Act
            var result = _tokenService.ValidateToken(token);

            // Assert
            result.Should().NotBeNull();
            if (result == null) return;

            result.Id.Should().Be(userDomain.Id);
            result.Login.Should().Be(userDomain.Login);
            result.IsAdmin.Should().Be(userDomain.IsAdmin);
        }
    }
}
