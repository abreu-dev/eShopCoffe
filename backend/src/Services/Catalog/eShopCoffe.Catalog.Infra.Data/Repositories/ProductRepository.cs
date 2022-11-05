using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Domain.Repositories;
using eShopCoffe.Catalog.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eShopCoffe.Catalog.Infra.Data.Repositories
{
    public class ProductRepository : Repository<ProductDomain, ProductData>, IProductRepository
    {
        public ProductRepository(IBaseContext context, IProductDataAdapter adapter) : base(context, adapter)
        {
        }

        public CurrencyDomain? GetCurrencyByProductId(Guid productId)
        {
            var product = _context.Query<ProductData>()
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == productId);

            if (product == null) return null;

            return new CurrencyDomain(product.CurrencyValue, product.CurrencyCode);
        }
    }
}
