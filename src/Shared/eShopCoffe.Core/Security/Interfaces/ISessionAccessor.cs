namespace eShopCoffe.Core.Security.Interfaces
{
    public interface ISessionAccessor
    {
        IAuthenticatedUser? User { get; }
        Guid UserId { get; }

        void Authenticate(IAuthenticatedUser user);
    }
}
