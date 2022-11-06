namespace eShopCoffe.Contracts.Contracts.OrderingContracts
{
    public class OrderItemCreationDto
    {
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
    }
}
