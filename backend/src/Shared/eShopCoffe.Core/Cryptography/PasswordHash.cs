using eShopCoffe.Core.Cryptography.Interfaces;

namespace eShopCoffe.Core.Cryptography
{
    public class PasswordHash : IPasswordHash
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
