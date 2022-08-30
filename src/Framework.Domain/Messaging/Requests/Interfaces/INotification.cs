namespace Framework.Core.Messaging.Requests.Interfaces
{
    public interface INotification
    {
        string Key { get; }
        string Value { get; }
    }
}
