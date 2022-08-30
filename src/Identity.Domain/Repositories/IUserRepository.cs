using Framework.Core.Domain.Repositories.Interfaces;
using Identity.Domain.Entities;

namespace Identity.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserDomain>
    {
        UserDomain? GetByLoginAndPassword(string login, string password);

        void UpdateLastAccess(Guid id);
    }
}
