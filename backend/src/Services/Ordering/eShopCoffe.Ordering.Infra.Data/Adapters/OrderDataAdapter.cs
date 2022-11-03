using eShopCoffe.Core.Data.Adapters;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Adapters
{
    public class OrderDataAdapter : DataAdapter<OrderDomain, OrderData>, IOrderDataAdapter
    {
        private readonly IOrderItemDataAdapter _orderItemDataAdapter;
        private readonly IOrderEventDataAdapter _orderEventDataAdapter;

        public OrderDataAdapter(IOrderItemDataAdapter orderItemDataAdapter,
                                IOrderEventDataAdapter orderEventDataAdapter)
        {
            _orderItemDataAdapter = orderItemDataAdapter;
            _orderEventDataAdapter = orderEventDataAdapter;
        }

        public override OrderDomain? Transform(OrderData? data)
        {
            if (data == null) return null;

            var address = new AddressDomain(data.Cep, data.Number);
            var currency = new CurrencyDomain(data.CurrencyValue, data.CurrencyCode);
            var events = _orderEventDataAdapter.Transform(data.Events).ToList();
            var items = _orderItemDataAdapter.Transform(data.Items).ToList();

            return new OrderDomain(data.Id,
                                   data.UserId,
                                   address,
                                   data.Status,
                                   data.PaymentMethod,
                                   currency,
                                   events,
                                   items);
        }

        public override OrderData? Transform(OrderDomain? domain)
        {
            if (domain == null) return null;

            var events = _orderEventDataAdapter.Transform(domain.Events).ToList();
            var items = _orderItemDataAdapter.Transform(domain.Items).ToList();

            return new OrderData()
            {
                Id = domain.Id,
                UserId = domain.UserId,
                Cep = domain.Address.Cep,
                Number = domain.Address.Number,
                Status = domain.Status,
                PaymentMethod = domain.PaymentMethod,
                CurrencyCode = domain.Currency.Code,
                CurrencyValue = domain.Currency.Value,
                Events = events,
                Items = items
            };
        }
    }
}
