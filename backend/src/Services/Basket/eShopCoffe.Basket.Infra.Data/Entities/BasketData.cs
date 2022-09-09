using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Identity.Infra.Data.Entities;

namespace eShopCoffe.Basket.Infra.Data.Entities
{
    public class BasketData : EntityData
    {
        public static string TableName => "Basket";

        public Guid UserId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserData User { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ICollection<BasketItemData> Items { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
