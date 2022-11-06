namespace eShopCoffe.Contracts.Contracts.ProductContracts
{
    public class ProductCreationDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int QuantityAvailable { get; set; }
        public decimal Value { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal CurrencyValue { get; set; }
    }
}
