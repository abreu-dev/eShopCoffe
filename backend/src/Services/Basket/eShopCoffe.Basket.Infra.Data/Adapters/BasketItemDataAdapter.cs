using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Basket.Infra.Data.Entities;
using eShopCoffe.Core.Data.Adapters;

namespace eShopCoffe.Basket.Infra.Data.Adapters
{
    public class BasketItemDataAdapter : DataAdapter<BasketItemDomain, BasketItemData>, IBasketItemDataAdapter
    {
        public override BasketItemDomain? Transform(BasketItemData? data)
        {
            if (data == null) return null;

            return new BasketItemDomain(data.Id, data.ProductId, data.BasketId, data.Amount);
        }

        public override BasketItemData? Transform(BasketItemDomain? domain)
        {
            if (domain == null) return null;

            return new BasketItemData()
            {
                Id = domain.Id,
                ProductId = domain.ProductId,
                BasketId = domain.BasketId,
                Amount = domain.Amount
            };
        }
    }
}
