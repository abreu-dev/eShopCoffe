using eShopCoffe.Core.Data.Adapters;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Adapters
{
    public class OrderEventDataAdapter : DataAdapter<OrderEventDomain, OrderEventData>, IOrderEventDataAdapter
    {
        public override OrderEventDomain? Transform(OrderEventData? data)
        {
            if (data == null) return null;

            return new OrderEventDomain(data.Id, data.OrderId, data.Status, data.Date);
        }

        public override OrderEventData? Transform(OrderEventDomain? domain)
        {
            if (domain == null) return null;

            return new OrderEventData()
            {
                Id = domain.Id,
                OrderId = domain.OrderId,
                Status = domain.Status,
                Date = domain.Date,
            };
        }
    }
}
