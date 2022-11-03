using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Ordering.Application.Contracts;
using eShopCoffe.Ordering.Application.Queries.Handlers;
using eShopCoffe.Ordering.Application.Queries.OrderQueries;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Ordering.Application
{
    public static class OrderingApplicationBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Queries(services);
        }

        private static void Queries(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<PagedOrdersQuery, IPagedList<OrderDto>>, OrderQueryHandler>();
            services.AddScoped<IQueryHandler<OrderDetailQuery, OrderDto>, OrderQueryHandler>();
        }
    }
}
