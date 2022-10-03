using eShopCoffe.Core.Cryptography;

namespace eShopCoffe.Core.Tests.Cryptography
{
    public class PasswordHashTests
    {
        private readonly PasswordHash _passwordHash;

        public PasswordHashTests()
        {
            _passwordHash = new PasswordHash();
        }

        [Fact]
        public void Hash_ShouldReturnHashedPassword()
        {
            // Arrange
            var password = "Password";

            // Act
            var hashedPassword = _passwordHash.Hash(password);

            // Assert
            hashedPassword.Should().NotBeNull();
            hashedPassword.Should().NotBe(password);
        }

        [Fact]
        public void Verify_ShouldReturnTrueWhenMatchPasswords()
        {
            // Arrange
            var password = "Password";
            var hashedPassword = _passwordHash.Hash(password);

            // Act
            var result = _passwordHash.Verify(password, hashedPassword);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Verify_ShouldReturnFalseWhenMatchPasswords()
        {
            // Arrange
            var password = "Password";
            var hashedPassword = _passwordHash.Hash("password");

            // Act
            var result = _passwordHash.Verify(password, hashedPassword);

            // Assert
            result.Should().BeFalse();
        }
    }
}
