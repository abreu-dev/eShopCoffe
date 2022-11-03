using eShopCoffe.Core.Data;
using eShopCoffe.Core.Domain.Repositories;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Domain.Repositories;
using eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Repositories
{
    public class OrderRepository : Repository<OrderDomain, OrderData>, IOrderRepository
    {
        public OrderRepository(IBaseContext context, IOrderDataAdapter adapter) : base(context, adapter)
        {
        }
    }
}
