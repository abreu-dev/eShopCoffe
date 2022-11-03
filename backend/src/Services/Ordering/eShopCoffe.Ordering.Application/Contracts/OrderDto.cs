using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Ordering.Application.Contracts
{
    public class OrderDto : IQueryResult
    {
        public Guid Id { get; set; }
        public OrderAddressDto Address { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal CurrencyValue { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public IEnumerable<OrderEventDto> Events { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
