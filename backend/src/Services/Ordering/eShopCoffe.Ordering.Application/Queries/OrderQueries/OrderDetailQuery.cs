using eShopCoffe.Core.Messaging.Requests.Interfaces;
using eShopCoffe.Ordering.Application.Contracts;

namespace eShopCoffe.Ordering.Application.Queries.OrderQueries
{
    public class OrderDetailQuery : IQuery<OrderDto>
    {
        public Guid OrderId { get; private set; }

        public OrderDetailQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
