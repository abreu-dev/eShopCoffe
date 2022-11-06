using eShopCoffe.Catalog.Application.Queries.Handlers;
using eShopCoffe.Catalog.Application.Queries.ProductQueries;
using eShopCoffe.Contracts.Contracts.ProductContracts;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Catalog.Application
{
    public static class CatalogApplicationBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Queries(services);
        }

        private static void Queries(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<PagedProductsQuery, IPagedList<ProductDto>>, ProductQueryHandler>();
            services.AddScoped<IQueryHandler<ProductDetailQuery, ProductDto>, ProductQueryHandler>();
        }
    }
}
