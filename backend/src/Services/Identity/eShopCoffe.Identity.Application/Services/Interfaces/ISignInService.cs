using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Application.Services.Interfaces
{
    public interface ISignInService
    {
        IResult<UserDomain> SignIn(string username, string password);
    }
}
