using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Application.Services.Interfaces
{
    public interface ISignUpService
    {
        IResult<UserDomain> SignUp(string username, string email, string password);
    }
}
