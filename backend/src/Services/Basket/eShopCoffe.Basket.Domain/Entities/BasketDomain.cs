using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Basket.Domain.Entities
{
    public class BasketDomain : EntityDomain
    {
        public Guid UserId { get; private set; }

        public ICollection<BasketItemDomain> Items { get; private set; }

        public BasketDomain(Guid userId)
        {
            UserId = userId;
            Items = new List<BasketItemDomain>();
        }

        public BasketDomain(Guid id, Guid userId, ICollection<BasketItemDomain> items) : base(id)
        {
            UserId = userId;
            Items = items;
        }

        public void AddOrUpdateItem(Guid productId, int amount, bool increase = false)
        {
            var item = FindItemByProductId(productId);

            if (item == null)
            {
                var newItem = new BasketItemDomain(productId, Id, amount);
                Items.Add(newItem);
            }
            else
            {
                item.SetAmount(increase ? item.Amount + amount : amount);
            }
        }

        public void RemoveItemByProductId(Guid productId)
        {
            var item = FindItemByProductId(productId);

            if (item != null)
            {
                Items.Remove(item);
            }
        }

        private BasketItemDomain? FindItemByProductId(Guid productId)
        {
            return Items.SingleOrDefault(x => x.ProductId == productId);
        }
    }
}
