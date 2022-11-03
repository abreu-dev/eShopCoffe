using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data.Adapters;
using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Catalog.Infra.Data.Adapters
{
    public class ProductDataAdapter : DataAdapter<ProductDomain, ProductData>, IProductDataAdapter
    {
        public override ProductDomain? Transform(ProductData? data)
        {
            if (data == null) return null;

            return new ProductDomain(data.Id, data.Name, data.Description, data.ImageUrl, data.QuantityAvailable, new CurrencyDomain(data.CurrencyValue, data.CurrencyCode));
        }

        public override ProductData? Transform(ProductDomain? domain)
        {
            if (domain == null) return null;

            return new ProductData()
            {
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                ImageUrl = domain.ImageUrl,
                QuantityAvailable = domain.QuantityAvailable,
                CurrencyValue = domain.Currency.Value,
                CurrencyCode = domain.Currency.Code
            };
        }
    }
}
