using eShopCoffe.Core.Data.Adapters;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Adapters
{
    public class OrderItemDataAdapter : DataAdapter<OrderItemDomain, OrderItemData>, IOrderItemDataAdapter
    {
        public override OrderItemDomain? Transform(OrderItemData? data)
        {
            if (data == null) return null;

            var currency = new CurrencyDomain(data.CurrencyValue, data.CurrencyCode);
            return new OrderItemDomain(data.Id, data.ProductId, data.OrderId, data.Amount, currency);
        }

        public override OrderItemData? Transform(OrderItemDomain? domain)
        {
            if (domain == null) return null;

            return new OrderItemData()
            {
                Id = domain.Id,
                ProductId = domain.ProductId,
                OrderId = domain.OrderId,
                Amount = domain.Amount,
                CurrencyCode = domain.Currency.Code,
                CurrencyValue = domain.Currency.Value
            };
        }
    }
}
