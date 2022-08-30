using Framework.Core.Security.Interfaces;

namespace Framework.Core.Security
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public Guid Id { get; }
        public string Login { get; }
        public bool IsAdmin { get; }

        public AuthenticatedUser(Guid id, string login, bool isAdmin)
        {
            Id = id;
            Login = login;
            IsAdmin = isAdmin;
        }
    }
}
