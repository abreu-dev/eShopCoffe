using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Requests
{
    public class Notification : INotification
    {
        public string Key { get; }
        public string Value { get; }

        public Notification(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
