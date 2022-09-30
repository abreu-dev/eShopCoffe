using eShopCoffe.Core.Security.Interfaces;

namespace eShopCoffe.Core.Security
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public Guid Id { get; }
        public string Username { get; }
        public bool IsAdmin { get; }

        public AuthenticatedUser(Guid id, string username, bool isAdmin)
        {
            Id = id;
            Username = username;
            IsAdmin = isAdmin;
        }
    }
}
