using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        IResult<UserDomain> Authenticate(string username, string password);
    }
}
