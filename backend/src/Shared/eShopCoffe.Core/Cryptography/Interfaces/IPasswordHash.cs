namespace eShopCoffe.Core.Cryptography.Interfaces
{
    public interface IPasswordHash
    {
        string Hash(string password);
        bool Verify(string password, string hashedPassword);
    }
}
