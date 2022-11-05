using eShopCoffe.Core.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Infra.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces
{
    public interface IOrderItemDataAdapter : IDataAdapter<OrderItemDomain, OrderItemData>
    {
    }
}
