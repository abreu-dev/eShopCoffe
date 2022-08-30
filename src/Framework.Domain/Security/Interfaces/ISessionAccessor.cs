namespace Framework.Core.Security.Interfaces
{
    public interface ISessionAccessor
    {
        IAuthenticatedUser? User { get; }

        void Authenticate(IAuthenticatedUser user);
    }
}
