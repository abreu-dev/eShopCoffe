using eShopCoffe.Core.Validators.Interfaces;

namespace eShopCoffe.Identity.Domain.Validators.Interfaces
{
    public interface ISignUpValidator
    {
        IResult Validate(string username, string email, string password);
    }
}
