using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Basket.Infra.Data.Entities;
using eShopCoffe.Core.Data.Adapters;

namespace eShopCoffe.Basket.Infra.Data.Adapters
{
    public class BasketDataAdapter : DataAdapter<BasketDomain, BasketData>, IBasketDataAdapter
    {
        private readonly IBasketItemDataAdapter _basketItemDataAdapter;

        public BasketDataAdapter(IBasketItemDataAdapter basketItemDataAdapter)
        {
            _basketItemDataAdapter = basketItemDataAdapter;
        }

        public override BasketDomain? Transform(BasketData? data)
        {
            if (data == null) return null;

            var items = _basketItemDataAdapter.Transform(data.Items).ToList();
            return new BasketDomain(data.Id, data.UserId, items);
        }

        public override BasketData? Transform(BasketDomain? domain)
        {
            if (domain == null) return null;

            var items = _basketItemDataAdapter.Transform(domain.Items).ToList();
            return new BasketData()
            {
                Id = domain.Id,
                UserId = domain.UserId,
                Items = items
            };
        }
    }
}
