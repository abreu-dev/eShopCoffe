using eShopCoffe.Core.Email.Interfaces;
using eShopCoffe.Core.Validators;
using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Application.Services.Interfaces;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Domain.Validators.Interfaces;

namespace eShopCoffe.Identity.Application.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISignUpValidator _signUpValidator;
        private readonly IEmailService _emailService;

        public SignUpService(
            IUserRepository userRepository,
            ISignUpValidator signUpValidator,
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _signUpValidator = signUpValidator;
            _emailService = emailService;
        }

        public IResult<UserDomain> SignUp(string username, string email, string password)
        {
            var validation = _signUpValidator.Validate(username, email, password);

            if (validation.HasSucceed)
            {
                var user = new UserDomain(username, email);
                _userRepository.Add(user, password);
                _userRepository.UnitOfWork.Complete();

                _emailService.SendAccountCreationEmail(email, username);

                return Result<UserDomain>.Success(user);
            }

            return Result<UserDomain>.Failure(
                validation.ErrorCode ?? "SignUpFailed",
                validation.ErrorMessage ?? "Unexpected error.");
        }
    }
}
