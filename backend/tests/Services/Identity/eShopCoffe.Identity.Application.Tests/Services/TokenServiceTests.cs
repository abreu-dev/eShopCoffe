using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Identity.Application.Services;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Application.Tests.Services
{
    public class TokenServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtSettings _jwtSettings;
        private readonly TokenService _tokenService;

        public TokenServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _jwtSettings = Substitute.For<IJwtSettings>();

            _tokenService = new TokenService(_userRepository, _jwtSettings);
        }

        [Fact]
        public void GenerateAuthenticationToken_ShouldReturnToken()
        {
            // Arrange
            var userDomain = new UserDomain(Guid.NewGuid(), "Username", "Password");
            _jwtSettings.Expires.Returns(120);
            _jwtSettings.Secret.Returns(Guid.NewGuid().ToString());

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
            var userDomain = new UserDomain(Guid.NewGuid(), "Username", "Password");
            _jwtSettings.Expires.Returns(120);
            _jwtSettings.Secret.Returns(Guid.NewGuid().ToString());
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
            var userDomain = new UserDomain(Guid.NewGuid(), "Username", "Password");
            _jwtSettings.Expires.Returns(120);
            _jwtSettings.Secret.Returns(Guid.NewGuid().ToString());
            var token = _tokenService.GenerateAuthenticationToken(userDomain);
            _userRepository.GetById(userDomain.Id).Returns(userDomain);

            // Act
            var result = _tokenService.ValidateToken(token);

            // Assert
            result.Should().NotBeNull();
            if (result == null) return;

            result.Id.Should().Be(userDomain.Id);
            result.Username.Should().Be(userDomain.Username);
            result.IsAdmin.Should().Be(userDomain.IsAdmin);
        }
    }
}
