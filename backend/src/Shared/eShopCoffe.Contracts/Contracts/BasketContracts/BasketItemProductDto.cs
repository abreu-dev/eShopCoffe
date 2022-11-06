namespace eShopCoffe.Contracts.Contracts.BasketContracts
{
    public class BasketItemProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal CurrencyValue { get; set; }
    }
}
