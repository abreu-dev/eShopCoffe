using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAuthenticationToken(UserDomain user);
        IAuthenticatedUser? ValidateToken(string? token);
    }
}
