using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Ordering.Domain.Entities
{
    public class OrderItemDomain : EntityDomain
    {
        public Guid ProductId { get; private set; }
        public Guid OrderId { get; private set; }
        public int Amount { get; private set; }
        public CurrencyDomain Currency { get; private set; }

        public OrderItemDomain(Guid productId,
                               Guid orderId,
                               int amount,
                               CurrencyDomain currency)
        {
            ProductId = productId;
            OrderId = orderId;
            Amount = amount;
            Currency = currency;
        }

        public OrderItemDomain(Guid id,
                               Guid productId,
                               Guid orderId,
                               int amount,
                               CurrencyDomain currency) : base(id)
        {
            ProductId = productId;
            OrderId = orderId;
            Amount = amount;
            Currency = currency;
        }

        public decimal GetValue()
        {
            return Amount * Currency.Value;
        }
    }
}
