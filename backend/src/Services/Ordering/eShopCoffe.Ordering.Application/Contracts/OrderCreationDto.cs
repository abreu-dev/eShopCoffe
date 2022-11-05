namespace eShopCoffe.Ordering.Application.Contracts
{
    public class OrderCreationDto
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderAddressDto Address { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string PaymentMethod { get; set; } = string.Empty;

        public IEnumerable<OrderItemCreationDto> Items { get; set; } = new List<OrderItemCreationDto>();

        public bool ClearBasket { get; set; }
    }
}
