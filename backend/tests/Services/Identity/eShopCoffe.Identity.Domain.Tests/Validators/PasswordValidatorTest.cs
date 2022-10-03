using eShopCoffe.Identity.Domain.Validators;

namespace eShopCoffe.Identity.Domain.Tests.Validators
{
    public class PasswordValidatorTest
    {
        private readonly PasswordValidator _passwordValidator;

        public PasswordValidatorTest()
        {
            _passwordValidator = new PasswordValidator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("am4#YU1")] // MinimumEightCaracters
        [InlineData("am4#yu1;")] // AtLeastOneUpperCaseLetter
        [InlineData("AM4#YU1;")] // AtLeastOneLowerCaseLetter
        [InlineData("amb#YUc;")] // AtLeastOneDigit
        [InlineData("am45YU1a")] // AtLeastOneSpecialCharacter
        public void Validate_WhenPasswordDoesNotMatchRequirements_ShouldReturnFailure(string password)
        {
            // Act
            var result = _passwordValidator.Validate(password);

            // Assert
            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("PasswordValidatorFailed");
            result.ErrorMessage.Should().Be("Password must have minimum eight characters, at least one upper case letter, one lower case letter, one digit and one special character.");
        }

        [Fact]
        public void Validate_WhenValid_ShouldReturnSucceed()
        {
            // Arrange
            var password = "am4#YU1;";

            // Act
            var result = _passwordValidator.Validate(password);

            // Assert
            result.HasSucceed.Should().BeTrue();
        }
    }
}
