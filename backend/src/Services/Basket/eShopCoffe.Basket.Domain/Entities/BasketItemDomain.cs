using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Basket.Domain.Entities
{
    public class BasketItemDomain : EntityDomain
    {
        public Guid ProductId { get; private set; }
        public Guid BasketId { get; private set; }
        public int Amount { get; private set; }

        public BasketItemDomain(Guid productId, Guid basketId, int amount)
        {
            ProductId = productId;
            BasketId = basketId;
            Amount = amount;
        }

        public BasketItemDomain(Guid id, Guid productId, Guid basketId, int amount) : base(id)
        {
            ProductId = productId;
            BasketId = basketId;
            Amount = amount;
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }
    }
}
