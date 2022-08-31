using eShopCoffe.Core.Security.Interfaces;

namespace eShopCoffe.Core.Security
{
    public class SessionAccessor : ISessionAccessor
    {
        public IAuthenticatedUser? User { get; private set; }

        public void Authenticate(IAuthenticatedUser user)
        {
            User = user;
        }
    }
}
