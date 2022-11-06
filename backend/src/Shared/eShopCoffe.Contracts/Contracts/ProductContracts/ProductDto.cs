using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Contracts.Contracts.ProductContracts
{
    public class ProductDto : IQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int QuantityAvailable { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal CurrencyValue { get; set; }
    }
}
