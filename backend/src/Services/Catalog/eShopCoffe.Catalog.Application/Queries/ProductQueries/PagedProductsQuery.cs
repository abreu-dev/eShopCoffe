using eShopCoffe.Catalog.Application.Contracts.ProductContracts;
using eShopCoffe.Catalog.Application.Parameters.Interfaces;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Catalog.Application.Queries.ProductQueries
{
    public class PagedProductsQuery : IQuery<IPagedList<ProductDto>>
    {
        public IProductParameters Parameters { get; private set; }

        public PagedProductsQuery(IProductParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
