using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Domain.Repositories;
using eShopCoffe.Catalog.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Domain.Repositories;

namespace eShopCoffe.Catalog.Infra.Data.Repositories
{
    public class ProductRepository : Repository<ProductDomain, ProductData>, IProductRepository
    {
        public ProductRepository(IBaseContext context, IProductDataAdapter adapter) : base(context, adapter)
        {
        }
    }
}
