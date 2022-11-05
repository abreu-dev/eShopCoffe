using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Ordering.Domain.Enums;

namespace eShopCoffe.Ordering.Domain.Entities
{
    public class OrderEventDomain : EntityDomain
    {
        public Guid OrderId { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime Date { get; private set; }

        public OrderEventDomain(Guid orderId, OrderStatus status, DateTime date)
        {
            OrderId = orderId;
            Status = status;
            Date = date;
        }

        public OrderEventDomain(Guid id, Guid orderId, OrderStatus status, DateTime date) : base(id)
        {
            OrderId = orderId;
            Status = status;
            Date = date;
        }
    }
}
