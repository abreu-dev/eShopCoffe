using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Ordering.Domain.Enums;

namespace eShopCoffe.Ordering.Domain.Entities
{
    public class OrderDomain : EntityDomain
    {
        public Guid UserId { get; private set; }
        public AddressDomain Address { get; private set; }
        public OrderStatus Status { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public CurrencyDomain Currency { get; private set; }

        public ICollection<OrderEventDomain> Events { get; private set; }
        public ICollection<OrderItemDomain> Items { get; private set; }

        public OrderDomain(Guid userId,
                           AddressDomain address,
                           PaymentMethod paymentMethod)
        {
            UserId = userId;
            Address = address;
            PaymentMethod = paymentMethod;
            Currency = new CurrencyDomain(0, string.Empty);
            Events = new List<OrderEventDomain>();
            Items = new List<OrderItemDomain>();

            SetStatus(OrderStatus.Pending);
        }

        public OrderDomain(Guid id,
                           Guid userId,
                           AddressDomain address,
                           OrderStatus status,
                           PaymentMethod paymentMethod,
                           CurrencyDomain currency,
                           ICollection<OrderEventDomain> events,
                           ICollection<OrderItemDomain> items) : base(id)
        {
            UserId = userId;
            Address = address;
            Status = status;
            PaymentMethod = paymentMethod;
            Currency = currency;
            Events = events;
            Items = items;
        }

        private void SetStatus(OrderStatus status)
        {
            Status = status;
            Events.Add(new OrderEventDomain(Id, status, DateTime.UtcNow));
        }

        public void AddItem(Guid productId, int amount, CurrencyDomain currency)
        {
            Items.Add(new OrderItemDomain(productId, Id, amount, currency));
            RecalculateCurrency();
        }

        private void RecalculateCurrency()
        {
            Currency.SetCode(Items.FirstOrDefault()?.Currency.Code ?? string.Empty);
            Currency.SetValue(Items.Sum(item => item.GetValue()));
        }
    }
}
