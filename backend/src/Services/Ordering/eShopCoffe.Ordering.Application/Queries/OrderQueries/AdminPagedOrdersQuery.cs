using eShopCoffe.Contracts.Contracts.OrderingContracts;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using eShopCoffe.Ordering.Application.Parameters.Interfaces;

namespace eShopCoffe.Ordering.Application.Queries.OrderQueries
{
    public class AdminPagedOrdersQuery : IQuery<IPagedList<OrderDto>>
    {
        public IOrderParameters Parameters { get; private set; }

        public AdminPagedOrdersQuery(IOrderParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
