using eShopCoffe.Contracts.Contracts.OrderingContracts;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Ordering.Application.Queries.Handlers;
using eShopCoffe.Ordering.Application.Queries.OrderQueries;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Ordering.Application.Tests
{
    public class OrderingApplicationBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public OrderingApplicationBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDataServices()
        {
            // Act
            OrderingApplicationBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(3).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IQueryHandler<AdminPagedOrdersQuery, IPagedList<OrderDto>>), typeof(OrderQueryHandler));
            ValidateService(typeof(IQueryHandler<PagedOrdersQuery, IPagedList<OrderDto>>), typeof(OrderQueryHandler));
            ValidateService(typeof(IQueryHandler<OrderDetailQuery, OrderDto>), typeof(OrderQueryHandler));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}
