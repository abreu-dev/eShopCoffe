using eShopCoffe.Catalog.Application.Contracts.ProductContracts;
using eShopCoffe.Catalog.Application.Queries.ProductQueries;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Data.Pagination;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;

namespace eShopCoffe.Catalog.Application.Queries.Handlers
{
    public class ProductQueryHandler :
        IQueryHandler<PagedProductsQuery, IPagedList<ProductDto>>
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

            var rnd = new Random();

            var dtos = (from product in source
                        select new ProductDto()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            QuantityAvailable = product.QuantityAvailable.ToString(),
                            Price = Math.Round(new decimal(rnd.Next(1, 99))).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture),
                            ImageUrl = "https://brmotorolanew.vtexassets.com/arquivos/ids/162724-800-auto?v=637992717540670000&width=800&height=auto&aspect=true"
                        })
                        .Skip(query.Parameters.Page * query.Parameters.Size)
                        .Take(query.Parameters.Size)
                        .ToList();

            IPagedList<ProductDto> pagedList = new PagedList<ProductDto>(dtos, totalItems, query.Parameters.Page, query.Parameters.Size);
            return Task.FromResult(pagedList);
        }
    }
}
