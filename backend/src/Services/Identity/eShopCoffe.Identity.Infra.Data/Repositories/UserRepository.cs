using eShopCoffe.Core.Cryptography.Interfaces;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Domain.Repositories;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Identity.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShopCoffe.Identity.Infra.Data.Repositories
{
    public class UserRepository : Repository<UserDomain, UserData>, IUserRepository
    {
        private readonly IPasswordHash _passwordHash;

        public UserRepository(
            IBaseContext context,
            IUserDataAdapter adapter,
            IPasswordHash passwordHash) : base(context, adapter)
        {
            _passwordHash = passwordHash;
        }

        public override void Update(UserDomain domain)
        {
            var data = _adapter.Transform(domain);
            if (data != null)
            {
                _context.UpdateData(data);

                var existingData = _context.GetDbSet<UserData>().SingleOrDefault(x => x.Id == data.Id);
                if (existingData != null)
                {
                    var entry = _context.GetDbEntry(existingData);
                    if (entry != null)
                    {
                        entry.Property(x => x.LastAccess).IsModified = false;
                    }
                }
            }
        }

        public UserDomain? GetByUsernameAndPassword(string username, string password)
        {
            var user = _context.Query<UserData>()
                .AsNoTracking()
                .FirstOrDefault(x => x.Username == username && _passwordHash.Verify(password, x.HashedPassword));

            if (user == null) return null;

            return _adapter.Transform(user);
        }

        public void UpdateLastAccess(Guid id)
        {
            var user = _context.Query<UserData>()
                .FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                user.LastAccess = DateTime.UtcNow;
            }
        }
    }
}
