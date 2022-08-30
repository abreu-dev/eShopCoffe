using Framework.Core.Validators;
using Framework.Core.Validators.Interfaces;
using Identity.Application.Services.Interfaces;
using Identity.Domain.Entities;
using Identity.Domain.Repositories;

namespace Identity.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult<UserDomain> Authenticate(string login, string password)
        {
            var user = _userRepository.GetByLoginAndPassword(login, password);

            if (user == null)
            {
                return Result<UserDomain>.Failure("LoginFailed", "Incorrect username or password.");
            }

            return Result<UserDomain>.Success(user);
        }
    }
}
