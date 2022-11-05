namespace eShopCoffe.Ordering.Application.Contracts
{
    public class OrderItemCreationDto
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }
}
