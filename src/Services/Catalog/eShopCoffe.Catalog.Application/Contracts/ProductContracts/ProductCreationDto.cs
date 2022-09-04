namespace eShopCoffe.Catalog.Application.Contracts.ProductContracts
{
    public class ProductCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityAvailable { get; set; }
    }
}
