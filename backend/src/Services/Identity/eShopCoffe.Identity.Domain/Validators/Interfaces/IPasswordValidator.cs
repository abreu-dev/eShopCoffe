using eShopCoffe.Core.Validators.Interfaces;

namespace eShopCoffe.Identity.Domain.Validators.Interfaces
{
    public interface IPasswordValidator
    {
        IResult Validate(string password);
    }
}
