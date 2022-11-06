using eShopCoffe.Contracts.Contracts.OrderingContracts;
using eShopCoffe.Core.Messaging.Requests.Interfaces;

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
