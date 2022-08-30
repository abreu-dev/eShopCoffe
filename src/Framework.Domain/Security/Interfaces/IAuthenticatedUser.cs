namespace Framework.Core.Security.Interfaces
{
    public interface IAuthenticatedUser
    {
        Guid Id { get; }
        string Login { get; }
        bool IsAdmin { get; }
    }
}
