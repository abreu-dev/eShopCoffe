using eShopCoffe.Core.Domain.Repositories.Interfaces;
using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserDomain>
    {
        UserDomain? GetByLoginAndPassword(string login, string password);

        void UpdateLastAccess(Guid id);
    }
}
