using Framework.Core.Validators.Interfaces;
using Identity.Domain.Entities;

namespace Identity.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        IResult<UserDomain> Authenticate(string login, string password);
    }
}
