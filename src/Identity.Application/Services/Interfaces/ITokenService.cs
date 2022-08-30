using Framework.Core.Security.Interfaces;
using Identity.Domain.Entities;

namespace Identity.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAuthenticationToken(UserDomain user);
        IAuthenticatedUser? ValidateToken(string? token);
    }
}
