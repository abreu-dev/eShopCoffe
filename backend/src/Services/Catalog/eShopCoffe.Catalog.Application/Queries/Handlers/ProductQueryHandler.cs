using eShopCoffe.Catalog.Application.Queries.ProductQueries;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Contracts.Contracts.ProductContracts;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Data.Pagination;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;

namespace eShopCoffe.Catalog.Application.Queries.Handlers
{
    public class ProductQueryHandler :
        IQueryHandler<PagedProductsQuery, IPagedList<ProductDto>>,
        IQueryHandler<ProductDetailQuery, ProductDto>
    {
        private readonly IBaseContext _context;

        public ProductQueryHandler(IBaseContext context)
        {
            _context = context;
        }

        public Task<IPagedList<ProductDto>> Handle(PagedProductsQuery query, CancellationToken cancellationToken = default)
        {
            var source = _context.Query<ProductData>();

            source = source.OrderBy(p => p.Name);

            var totalItems = source.Count();

            var dtos = (from product in source
                        select new ProductDto()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            ImageUrl = product.ImageUrl,
                            QuantityAvailable = product.QuantityAvailable,
                            CurrencyCode = product.CurrencyCode,
                            CurrencyValue = product.CurrencyValue
                        })
                        .Skip(query.Parameters.Page * query.Parameters.Size)
                        .Take(query.Parameters.Size)
                        .ToList();

            IPagedList<ProductDto> pagedList = new PagedList<ProductDto>(dtos, totalItems, query.Parameters.Page, query.Parameters.Size);
            return Task.FromResult(pagedList);
        }

        public Task<ProductDto> Handle(ProductDetailQuery query, CancellationToken cancellationToken = default)
        {
            var product = _context.Query<ProductData>().FirstOrDefault(p => p.Id == query.ProductId);

            if (product == null)
                return Task.FromResult(new ProductDto());

            var productDto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                QuantityAvailable = product.QuantityAvailable,
                CurrencyCode = product.CurrencyCode,
                CurrencyValue = product.CurrencyValue
            };
            return Task.FromResult(productDto);
        }
    }
}
