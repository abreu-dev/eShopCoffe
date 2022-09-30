using eShopCoffe.Core.Domain.Repositories.Interfaces;
using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserDomain>
    {
        UserDomain? GetByUsernameAndPassword(string username, string password);

        void UpdateLastAccess(Guid id);
    }
}
