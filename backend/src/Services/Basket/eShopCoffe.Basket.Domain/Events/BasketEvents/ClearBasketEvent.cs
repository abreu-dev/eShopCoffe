using eShopCoffe.Core.Messaging.Requests;

namespace eShopCoffe.Basket.Domain.Events.BasketEvents
{
    public class ClearBasketEvent : Event
    {
        public Guid UserId { get; private set; }

        public ClearBasketEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
