using eShopCoffe.Core.Email.Interfaces;
using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Application.Services;
using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Domain.Validators.Interfaces;

namespace eShopCoffe.Identity.Application.Tests.Services
{
    public class PasswordResetServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordValidator _passwordValidator;
        private readonly IEmailService _emailService;
        private readonly PasswordResetService _passwordResetService;

        public PasswordResetServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _passwordValidator = Substitute.For<IPasswordValidator>();
            _emailService = Substitute.For<IEmailService>();
            _passwordResetService = new PasswordResetService(_userRepository, _passwordValidator, _emailService);
        }

        [Fact]
        public void RequestPasswordReset_WhenUserNotExists_ShouldDoNothing()
        {
            // Arrange
            var username = "Username";
            _userRepository.ExistsByUsername(username).Returns(false);

            // Act
            _passwordResetService.RequestPasswordReset(username).Wait();

            // Assert
            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.DidNotReceive().ChangeTemporaryPasswordResetCode(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.UnitOfWork.DidNotReceive().Complete();
        }

        [Fact]
        public void RequestPasswordReset_WhenUserExists_ShouldSetPasswordResetCode()
        {
            // Arrange
            var username = "Username";
            var email = "Email";
            _userRepository.ExistsByUsername(username).Returns(true);
            _userRepository.GetEmailByUsername(username).Returns(email);

            // Act
            _passwordResetService.RequestPasswordReset(username).Wait();

            // Assert
            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.Received(1).ChangeTemporaryPasswordResetCode(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.Received(1).ChangeTemporaryPasswordResetCode(username, Arg.Is<string>(x => x.Length == 6));

            _userRepository.Received(1).GetEmailByUsername(Arg.Any<string>());
            _userRepository.Received(1).GetEmailByUsername(username);

            _emailService.Received(1).SendRequestPasswordResetEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
            _emailService.Received(1).SendRequestPasswordResetEmail(email, username, Arg.Is<string>(x => x.Length == 6));

            _userRepository.UnitOfWork.Received(1).Complete();
        }

        [Fact]
        public void ConfirmPasswordReset_WhenUserNotExists_ShouldReturnFailure()
        {
            // Arrange
            var username = "Username";
            var newPassword = "NewPassword";
            var passwordResetCode = "PasswordResetCode";

            _userRepository.ExistsByUsername(username).Returns(false);

            // Act
            var result = _passwordResetService.ConfirmPasswordReset(username, newPassword, passwordResetCode);

            // Assert
            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.DidNotReceive().ValidateTemporaryPasswordResetCode(Arg.Any<string>(), Arg.Any<string>());

            _passwordValidator.DidNotReceive().Validate(Arg.Any<string>());

            _userRepository.DidNotReceive().ChangePassword(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.UnitOfWork.DidNotReceive().Complete();

            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("ConfirmPasswordResetFailed");
            result.ErrorMessage.Should().Be("User not found.");
        }

        [Fact]
        public void ConfirmPasswordReset_WhenInvalidPasswordResetCode_ShouldReturnFailure()
        {
            // Arrange
            var username = "Username";
            var newPassword = "NewPassword";
            var passwordResetCode = "PasswordResetCode";

            _userRepository.ExistsByUsername(username).Returns(true);
            _userRepository.ValidateTemporaryPasswordResetCode(username, passwordResetCode).Returns(false);

            // Act
            var result = _passwordResetService.ConfirmPasswordReset(username, newPassword, passwordResetCode);

            // Assert
            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.Received(1).ValidateTemporaryPasswordResetCode(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.Received(1).ValidateTemporaryPasswordResetCode(username, passwordResetCode);

            _passwordValidator.DidNotReceive().Validate(Arg.Any<string>());

            _userRepository.DidNotReceive().ChangePassword(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.UnitOfWork.DidNotReceive().Complete();

            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be("ConfirmPasswordResetFailed");
            result.ErrorMessage.Should().Be("Invalid password reset code.");
        }

        [Fact]
        public void ConfirmPasswordReset_WhenPasswordValidationFail_ShouldReturnFailure()
        {
            // Arrange
            var username = "Username";
            var newPassword = "NewPassword";
            var passwordResetCode = "PasswordResetCode";

            _userRepository.ExistsByUsername(username).Returns(true);
            _userRepository.ValidateTemporaryPasswordResetCode(username, passwordResetCode).Returns(true);

            var passwordValidationResult = Result.Failure("ErrorCode", "ErrorMessage");
            _passwordValidator.Validate(newPassword).Returns(passwordValidationResult);

            // Act
            var result = _passwordResetService.ConfirmPasswordReset(username, newPassword, passwordResetCode);

            // Assert
            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.Received(1).ValidateTemporaryPasswordResetCode(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.Received(1).ValidateTemporaryPasswordResetCode(username, passwordResetCode);

            _passwordValidator.Received(1).Validate(Arg.Any<string>());
            _passwordValidator.Received(1).Validate(newPassword);

            _userRepository.DidNotReceive().ChangePassword(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.UnitOfWork.DidNotReceive().Complete();

            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be(passwordValidationResult.ErrorCode);
            result.ErrorMessage.Should().Be(passwordValidationResult.ErrorMessage);
        }

        [Fact]
        public void ConfirmPasswordReset_WhenPasswordValidationSucceed_ShouldChangeUserPassword()
        {
            // Arrange
            var username = "Username";
            var newPassword = "NewPassword";
            var passwordResetCode = "PasswordResetCode";

            _userRepository.ExistsByUsername(username).Returns(true);
            _userRepository.ValidateTemporaryPasswordResetCode(username, passwordResetCode).Returns(true);

            var passwordValidationResult = Result.Success();
            _passwordValidator.Validate(newPassword).Returns(passwordValidationResult);

            // Act
            var result = _passwordResetService.ConfirmPasswordReset(username, newPassword, passwordResetCode);

            // Assert
            _userRepository.Received(1).ExistsByUsername(Arg.Any<string>());
            _userRepository.Received(1).ExistsByUsername(username);

            _userRepository.Received(1).ValidateTemporaryPasswordResetCode(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.Received(1).ValidateTemporaryPasswordResetCode(username, passwordResetCode);

            _passwordValidator.Received(1).Validate(Arg.Any<string>());
            _passwordValidator.Received(1).Validate(newPassword);

            _userRepository.Received(1).ChangePassword(Arg.Any<string>(), Arg.Any<string>());
            _userRepository.Received(1).ChangePassword(username, newPassword);

            _userRepository.UnitOfWork.Received(1).Complete();

            result.HasSucceed.Should().BeTrue();
        }
    }
}
