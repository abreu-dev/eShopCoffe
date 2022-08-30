using Framework.Core.Domain.Entities;

namespace Identity.Domain.Entities
{
    public class UserDomain : EntityDomain
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public UserDomain(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public UserDomain(Guid id, string login, string password, bool isAdmin = false) : base(id)
        {
            Login = login;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
