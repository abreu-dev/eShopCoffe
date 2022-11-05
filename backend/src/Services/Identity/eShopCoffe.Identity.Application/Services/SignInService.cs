using eShopCoffe.Core.Validators;
using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Application.Services.Interfaces;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;

namespace eShopCoffe.Identity.Application.Services
{
    public class SignInService : ISignInService
    {
        private readonly IUserRepository _userRepository;

        public SignInService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult<UserDomain> SignIn(string username, string password)
        {
            var user = _userRepository.GetByUsernameAndPassword(username, password);

            if (user == null)
            {
                return Result<UserDomain>.Failure("SignInFailed", "Nome de usuário ou senha incorretos.");
            }

            return Result<UserDomain>.Success(user);
        }
    }
}
