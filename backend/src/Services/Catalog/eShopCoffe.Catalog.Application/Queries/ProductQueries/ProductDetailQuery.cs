using eShopCoffe.Contracts.Contracts.ProductContracts;
using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Catalog.Application.Queries.ProductQueries
{
    public class ProductDetailQuery : IQuery<ProductDto>
    {
        public Guid ProductId { get; private set; }

        public ProductDetailQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
