using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Catalog.Domain.Entities
{
    public class ProductDomain : EntityDomain
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int QuantityAvailable { get; private set; }

        public ProductDomain(string name, string description, int quantityAvailable)
        {
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
        }

        public ProductDomain(Guid id, string name, string description, int quantityAvailable)
            : base(id)
        {
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
        }
    }
}
