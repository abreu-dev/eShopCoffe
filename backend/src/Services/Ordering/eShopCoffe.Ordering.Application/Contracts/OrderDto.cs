using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Ordering.Application.Contracts
{
    public class OrderDto : IQueryResult
    {
        public Guid Id { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderAddressDto Address { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal CurrencyValue { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public IEnumerable<OrderEventDto> Events { get; set; } = new List<OrderEventDto>();
        public IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
