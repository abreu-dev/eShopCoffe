using eShopCoffe.Core.Messaging.Requests;

namespace eShopCoffe.Identity.Domain.Events.UserEvents
{
    public class UserSignedInEvent : Event
    {
        public Guid UserId { get; private set; }

        public UserSignedInEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
