using Framework.Core.Messaging.Requests;

namespace Identity.Domain.Events.UserEvents
{
    public class UserLoggedInEvent : Event
    {
        public Guid UserId { get; private set; }

        public UserLoggedInEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
