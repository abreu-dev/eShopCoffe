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
        private static int MinutesToExpirePasswordResetCode = 15;

        private readonly IPasswordHash _passwordHash;

        public UserRepository(
            IBaseContext context,
            IUserDataAdapter adapter,
            IPasswordHash passwordHash) : base(context, adapter)
        {
            _passwordHash = passwordHash;
        }

        public void Add(UserDomain domain, string password)
        {
            var data = _adapter.Transform(domain);
            if (data == null) return;

            data.HashedPassword = _passwordHash.Hash(password);
            _context.AddData(data);
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
                .SingleOrDefault(x => x.Username == username);

            if (user == null) return null;

            if (!_passwordHash.Verify(password, user.HashedPassword)) return null;

            return _adapter.Transform(user);
        }

        public string GetEmailByUsername(string username)
        {
            return _context.Query<UserData>()
                .AsNoTracking()
                .Single(x => x.Username == username).Email;
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Query<UserData>()
                .AsNoTracking()
                .Any(x => x.Username == username);
        }

        public bool ExistsByEmail(string email)
        {
            return _context.Query<UserData>()
                .AsNoTracking()
                .Any(x => x.Email == email);
        }

        public bool ValidateTemporaryPasswordResetCode(string username, string passwordResetCode)
        {
            var user = _context.Query<UserData>()
                .AsNoTracking()
                .SingleOrDefault(x => x.Username == username);

            return user != null
                && user.ExpireTemporaryPasswordResetCode.HasValue
                && user.ExpireTemporaryPasswordResetCode.Value <= DateTime.UtcNow.AddMinutes(MinutesToExpirePasswordResetCode)
                && !string.IsNullOrEmpty(user.HashedTemporaryPasswordResetCode)
                && _passwordHash.Verify(passwordResetCode, user.HashedTemporaryPasswordResetCode);
        }

        public void UpdateLastAccess(Guid userId)
        {
            var user = _context.Query<UserData>()
                .SingleOrDefault(x => x.Id == userId);

            if (user != null)
            {
                user.LastAccess = DateTime.UtcNow;
                user.HashedTemporaryPasswordResetCode = null;
                user.ExpireTemporaryPasswordResetCode = null;
            }
        }

        public void ChangeTemporaryPasswordResetCode(string username, string temporaryPasswordResetCode)
        {
            var user = _context.Query<UserData>()
                .SingleOrDefault(x => x.Username == username);

            if (user != null)
            {
                user.HashedTemporaryPasswordResetCode = _passwordHash.Hash(temporaryPasswordResetCode);
                user.ExpireTemporaryPasswordResetCode = DateTime.UtcNow.AddMinutes(MinutesToExpirePasswordResetCode);
            }
        }

        public void ChangePassword(string username, string newPassword)
        {
            var user = _context.Query<UserData>()
                 .SingleOrDefault(x => x.Username == username);

            if (user != null)
            {
                user.HashedPassword = _passwordHash.Hash(newPassword);
                user.HashedTemporaryPasswordResetCode = null;
                user.ExpireTemporaryPasswordResetCode = null;
            }
        }
    }
}
