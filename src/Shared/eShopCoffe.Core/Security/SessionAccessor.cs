using eShopCoffe.Core.Exceptions;
using eShopCoffe.Core.Security.Interfaces;

namespace eShopCoffe.Core.Security
{
    public class SessionAccessor : ISessionAccessor
    {
        public IAuthenticatedUser? User { get; private set; }

        public Guid UserId => User != null ? User.Id 
            : throw new EShopCoffeException("User must be authenticated.");

        public void Authenticate(IAuthenticatedUser user)
        {
            User = user;
        }
    }
}
