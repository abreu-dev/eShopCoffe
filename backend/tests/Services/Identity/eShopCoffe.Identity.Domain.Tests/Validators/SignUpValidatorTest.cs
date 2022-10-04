using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Domain.Validators;
using eShopCoffe.Identity.Domain.Validators.Interfaces;

namespace eShopCoffe.Identity.Domain.Tests.Validators
{
    public class SignUpValidatorTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;
        private readonly SignUpValidator _signUpValidator;

        public SignUpValidatorTest()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _passwordValidator = Substitute.For<IPasswordValidator>();
            _signUpValidator = new SignUpValidator(_userRepository, _passwordValidator);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("abcde")]
        [InlineData("abcdeF")]
        [InlineData("abcde1")]
        [InlineData("abcde$")]
        [InlineData("abcdefghijklmn")]
        public void Validate_WhenUsernameDoesNotMatchRequirements_ShouldReturnFailure(string username)
        {
            // Arrange
            var email = "Email";
            var password = "Password";

            // Act
            var result = _signUpValidator.Validate(username, email, password);

            // Assert
            _passwordValidator.DidNotReceive().Validate(Arg.Any<string>());

            _userRepository.DidNotReceive().ExistsByUsername(Arg.Any<string>());

            _userRepository.DidNotReceive().ExistsByEmail(Arg.Any<string>());

            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("SignUpValidatorFailed");
            result.ErrorMessage.Should().Be("Username must have minimum six and maximum twelve characters and be formed only by lower case letters.");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("email")]
        [InlineData("email.com")]
        [InlineData("email@email")]
        public void Validate_WhenEmailDoesNotMatchRequirements_ShouldReturnFailure(string email)
        {
            // Arrange
            var username = "username";
            var password = "Password";

            // Act
            var result = _signUpValidator.Validate(username, email, password);

            // Assert
            _passwordValidator.DidNotReceive().Validate(Arg.Any<string>());

            _userRepository.DidNotReceive().ExistsByUsername(Arg.Any<string>());

            _userRepository.DidNotReceive().ExistsByEmail(Arg.Any<string>());

            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("SignUpValidatorFailed");
            result.ErrorMessage.Should().Be("Email must be valid.");
        }

        [Fact]
        public void Validate_WhenPasswordValidationFail_ShouldReturnFailure()
        {
            // Arrange
            var username = "username";
            var email = "email@email.com";
            var password = "Password";

            var passwordValidationResult = Result.Failure("ErrorCode", "ErrorMessage");
            _passwordValidator.Validate(password).Returns(passwordValidationResult);

            // Act
            var result = _signUpValidator.Validate(username, email, password);

            // Assert
            _passwordValidator.Received(1).Validate(Arg.Any<string>());
            _passwordValidator.Received(1).Validate(password);

            _userRepository.DidNotReceive().ExistsByUsername(Arg.Any<string>());

            _userRepository.DidNotReceive().ExistsByEmail(Arg.Any<string>());

            result.Should().Be(passwordValidationResult);
        }

        [Fact]
        public void Validate_WhenUsernameAlreadyInUse_ShouldReturnFailure()
        {
            // Arrange
            var username = "username";
            var email = "email@email.com";
            var password = "Password";

            var passwordValidationResult = Result.Success();
            _passwordValidator.Validate(password).Returns(passwordValidationResult);

            _userRepository.ExistsByUsername(username).Returns(true);

            // Act
            var result = _signUpValidator.Validate(username, email, password);

            // Assert
            _passwordValidator.Received(1).Validate(Arg.Any<string>());
            _passwordValidator.Received(1).Validate(password);

            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.DidNotReceive().ExistsByEmail(Arg.Any<string>());

            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("SignUpValidatorFailed");
            result.ErrorMessage.Should().Be("Username already in use.");
        }

        [Fact]
        public void Validate_WhenEmailAlreadyInUse_ShouldReturnFailure()
        {
            // Arrange
            var username = "username";
            var email = "email@email.com";
            var password = "Password";

            var passwordValidationResult = Result.Success();
            _passwordValidator.Validate(password).Returns(passwordValidationResult);

            _userRepository.ExistsByUsername(username).Returns(false);
            _userRepository.ExistsByEmail(email).Returns(true);

            // Act
            var result = _signUpValidator.Validate(username, email, password);

            // Assert
            _passwordValidator.Received(1).Validate(Arg.Any<string>());
            _passwordValidator.Received(1).Validate(password);

            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.Received(1).ExistsByEmail(Arg.Any<string>());
            _userRepository.Received(1).ExistsByEmail(email);

            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("SignUpValidatorFailed");
            result.ErrorMessage.Should().Be("Email already in use.");
        }

        [Fact]
        public void Validate_WhenValid_ShouldReturnSucceed()
        {
            // Arrange
            var username = "username";
            var email = "email@email.com";
            var password = "Password";

            var passwordValidationResult = Result.Success();
            _passwordValidator.Validate(password).Returns(passwordValidationResult);
            _userRepository.ExistsByUsername(username).Returns(false);
            _userRepository.ExistsByEmail(email).Returns(false);

            // Act
            var result = _signUpValidator.Validate(username, email, password);

            // Assert
            _passwordValidator.Received(1).Validate(Arg.Any<string>());
            _passwordValidator.Received(1).Validate(password);

            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.Received(1).ExistsByEmail(Arg.Any<string>());
            _userRepository.Received(1).ExistsByEmail(email);

            result.HasSucceed.Should().BeTrue();
        }
    }
}
