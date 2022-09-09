using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Infra.Data.Entities;
using eShopCoffe.Core.Data.Adapters.Interfaces;

namespace eShopCoffe.Basket.Infra.Data.Adapters.Interfaces
{
    public interface IBasketDataAdapter : IDataAdapter<BasketDomain, BasketData>
    {
    }
}
