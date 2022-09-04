using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data.Adapters;

namespace eShopCoffe.Catalog.Infra.Data.Adapters.Interfaces
{
    public interface IProductDataAdapter : IDataAdapter<ProductDomain, ProductData>
    {
    }
}
