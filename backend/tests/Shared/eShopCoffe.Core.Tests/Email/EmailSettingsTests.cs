using eShopCoffe.Core.Email;

namespace eShopCoffe.Core.Tests.Email
{
    public class EmailSettingsTests
    {
        private static readonly string ValidHost = "Host";
        private static readonly string ValidPort = "1";
        private static readonly string ValidAddress = "Address";
        private static readonly string ValidPassword = "Password";

        [Fact]
        public void Constructor_ShouldGetEnvironmentVariables()
        {
            // Arrange
            Environment.SetEnvironmentVariable("EMAIL_HOST", ValidHost);
            Environment.SetEnvironmentVariable("EMAIL_PORT", ValidPort);
            Environment.SetEnvironmentVariable("EMAIL_ADDRESS", ValidAddress);
            Environment.SetEnvironmentVariable("EMAIL_PASSWORD", ValidPassword);

            // Act
            var emailSettings = new EmailSettings();

            // Assert
            emailSettings.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_ShouldThrowException_WhenNotValidHost(string notValidHost)
        {
            // Arrange
            Environment.SetEnvironmentVariable("EMAIL_HOST", notValidHost);
            Environment.SetEnvironmentVariable("EMAIL_PORT", ValidPort);
            Environment.SetEnvironmentVariable("EMAIL_ADDRESS", ValidAddress);
            Environment.SetEnvironmentVariable("EMAIL_PASSWORD", ValidPassword);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new EmailSettings());

            // Assert
            exception.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_ShouldThrowException_WhenNotValidPort(string notValidPort)
        {
            // Arrange
            Environment.SetEnvironmentVariable("EMAIL_HOST", ValidHost);
            Environment.SetEnvironmentVariable("EMAIL_PORT", notValidPort);
            Environment.SetEnvironmentVariable("EMAIL_ADDRESS", ValidAddress);
            Environment.SetEnvironmentVariable("EMAIL_PASSWORD", ValidPassword);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new EmailSettings());

            // Assert
            exception.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_ShouldThrowException_WhenNotValidAddress(string notValidAddress)
        {
            // Arrange
            Environment.SetEnvironmentVariable("EMAIL_HOST", ValidHost);
            Environment.SetEnvironmentVariable("EMAIL_PORT", ValidPort);
            Environment.SetEnvironmentVariable("EMAIL_ADDRESS", notValidAddress);
            Environment.SetEnvironmentVariable("EMAIL_PASSWORD", ValidPassword);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new EmailSettings());

            // Assert
            exception.Should().NotBeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_ShouldThrowException_WhenNotValidPassword(string notValidPassword)
        {
            // Arrange
            Environment.SetEnvironmentVariable("EMAIL_HOST", ValidHost);
            Environment.SetEnvironmentVariable("EMAIL_PORT", ValidPort);
            Environment.SetEnvironmentVariable("EMAIL_ADDRESS", ValidAddress);
            Environment.SetEnvironmentVariable("EMAIL_PASSWORD", notValidPassword);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new EmailSettings());

            // Assert
            exception.Should().NotBeNull();
        }
    }
}
