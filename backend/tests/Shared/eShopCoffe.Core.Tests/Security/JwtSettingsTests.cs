using eShopCoffe.Core.Security;

namespace eShopCoffe.Core.Tests.Security
{
    public class JwtSettingsTests
    {
        private static readonly string ValidSecret = "SECRET";
        private static readonly string ValidExpires = "1";

        [Fact]
        public void Constructor_ShouldGetEnvironmentVariables()
        {
            // Arrange
            Environment.SetEnvironmentVariable("JWT_SECRET", ValidSecret);
            Environment.SetEnvironmentVariable("JWT_EXPIRES", ValidExpires);

            // Act
            var jwtSettings = new JwtSettings();

            // Assert
            jwtSettings.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_ShouldThrowException_WhenNotValidSecret(string notValidSecret)
        {
            // Arrange
            Environment.SetEnvironmentVariable("JWT_SECRET", notValidSecret);
            Environment.SetEnvironmentVariable("JWT_EXPIRES", ValidExpires);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new JwtSettings());

            // Assert
            exception.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_ShouldThrowException_WhenNotValidExpires(string notValidExpires)
        {
            // Arrange
            Environment.SetEnvironmentVariable("JWT_SECRET", ValidSecret);
            Environment.SetEnvironmentVariable("JWT_EXPIRES", notValidExpires);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new JwtSettings());

            // Assert
            exception.Should().NotBeNull();
        }
    }
}
