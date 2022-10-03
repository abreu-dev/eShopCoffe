namespace eShopCoffe.Core.Security.Interfaces
{
    public interface IAuthenticatedUser
    {
        Guid Id { get; }
        string Username { get; }
        bool IsAdmin { get; }
    }
}
