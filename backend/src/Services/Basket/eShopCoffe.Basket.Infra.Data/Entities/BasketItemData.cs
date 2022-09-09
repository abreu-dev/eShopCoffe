using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data.Entities;

namespace eShopCoffe.Basket.Infra.Data.Entities
{
    public class BasketItemData : EntityData
    {
        public static string TableName => "BasketItem";

        public Guid ProductId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductData Product { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Guid BasketId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BasketData Basket { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Amount { get; set; }
    }
}
