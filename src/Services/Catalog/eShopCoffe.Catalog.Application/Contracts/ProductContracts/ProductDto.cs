namespace eShopCoffe.Catalog.Application.Contracts.ProductContracts
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
