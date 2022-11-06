namespace eShopCoffe.Contracts.Contracts.OrderingContracts
{
    public class OrderItemDto
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal CurrencyValue { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
    }
}
