using eShopCoffe.Core.Messaging.Requests;

namespace eShopCoffe.Identity.Domain.Events.UserEvents
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
