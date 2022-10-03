using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Catalog.Domain.Entities
{
    public class ProductDomain : EntityDomain
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public int QuantityAvailable { get; private set; }
        public CurrencyDomain Currency { get; private set; }

        public ProductDomain(string name, string description, string imageUrl, int quantityAvailable, CurrencyDomain currency)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            QuantityAvailable = quantityAvailable;
            Currency = currency;
        }

        public ProductDomain(Guid id, string name, string description, string imageUrl, int quantityAvailable, CurrencyDomain currency)
            : base(id)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            QuantityAvailable = quantityAvailable;
            Currency = currency;
        }
    }
}
