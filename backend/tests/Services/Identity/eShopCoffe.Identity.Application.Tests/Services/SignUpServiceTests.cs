using eShopCoffe.Core.Email;
using eShopCoffe.Core.Email.Interfaces;
using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Application.Services;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Domain.Validators.Interfaces;

namespace eShopCoffe.Identity.Application.Tests.Services
{
    public class SignUpServiceTests
    {
        private readonly IUserRepository _userRepository;
        private readonly ISignUpValidator _signUpValidator;
        private readonly IEmailService _emailService;
        private readonly SignUpService _signUpService;

        public SignUpServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _signUpValidator = Substitute.For<ISignUpValidator>();
            _emailService = Substitute.For<IEmailService>();
            _signUpService = new SignUpService(_userRepository, _signUpValidator, _emailService);
        }

        [Fact]
        public void SignUp_WhenValidationFail_ShouldReturnFailure()
        {
            // Arrange
            var username = "Username";
            var email = "Email";
            var password = "Password";

            var signUpValidatorResult = Result.Failure("ErrorCode", "ErrorMessage");
            _signUpValidator.Validate(username, email, password).Returns(signUpValidatorResult);

            // Act
            var result = _signUpService.SignUp(username, email, password);

            // Assert
            result.HasSucceed.Should().BeFalse();
            result.ErrorCode.Should().Be(signUpValidatorResult.ErrorCode);
            result.ErrorMessage.Should().Be(signUpValidatorResult.ErrorMessage);
        }

        [Fact]
        public void SignUp_WhenValidationSucceed_ShouldReturnSuccess()
        {
            // Arrange
            var username = "Username";
            var email = "Email";
            var password = "Password";

            var signUpValidatorResult = Result.Success();
            _signUpValidator.Validate(username, email, password).Returns(signUpValidatorResult);

            // Act
            var result = _signUpService.SignUp(username, email, password);

            // Assert
            _userRepository.Received(1).Add(
                Arg.Any<UserDomain>(),
                Arg.Any<string>());
            _userRepository.Received(1).Add(
                Arg.Is<UserDomain>(x => x.Username == username && x.Email == email),
                password);

            _userRepository.UnitOfWork.Received(1).Complete();

            _emailService.Received(1).SendAccountCreationEmail(email, username);

            result.HasSucceed.Should().BeTrue();
        }
    }
}
