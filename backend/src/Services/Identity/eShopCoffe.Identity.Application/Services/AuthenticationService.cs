using eShopCoffe.Core.Validators;
using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Application.Services.Interfaces;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult<UserDomain> Authenticate(string username, string password)
        {
            var user = _userRepository.GetByUsernameAndPassword(username, password);

            if (user == null)
            {
                return Result<UserDomain>.Failure("SignInFailed", "Incorrect username or password.");
            }

            return Result<UserDomain>.Success(user);
        }
    }
}
