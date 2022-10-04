using eShopCoffe.Core.Domain.Repositories.Interfaces;
using eShopCoffe.Identity.Domain.Entities;

namespace eShopCoffe.Identity.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserDomain>
    {
        UserDomain? GetByUsernameAndPassword(string username, string password);

        string GetEmailByUsername(string username);

        bool ExistsByUsername(string username);
        bool ExistsByEmail(string email);
        bool ValidateTemporaryPasswordResetCode(string username, string passwordResetCode);

        void Add(UserDomain domain, string password);
        void UpdateLastAccess(Guid userId);
        void ChangeTemporaryPasswordResetCode(string username, string temporaryPasswordResetCode);
        void ChangePassword(string username, string newPassword);
    }
}
