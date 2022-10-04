using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Identity.Domain.Entities
{
    public class UserDomain : EntityDomain
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string HashedPassword { get; private set; }
        public bool IsAdmin { get; private set; }

        public UserDomain(string username, string email)
        {
            Username = username;
            Email = email;
            HashedPassword = string.Empty;
        }

        public UserDomain(Guid id, string username, string email, bool isAdmin = false) : base(id)
        {
            Username = username;
            Email = email;
            IsAdmin = isAdmin;
            HashedPassword = string.Empty;
        }
    }
}
