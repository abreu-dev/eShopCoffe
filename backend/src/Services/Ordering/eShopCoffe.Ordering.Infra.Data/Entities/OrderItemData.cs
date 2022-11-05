using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data.Entities;

namespace eShopCoffe.Ordering.Infra.Data.Entities
{
    public class OrderItemData : EntityData
    {
        public static string TableName => "OrderItem";

        public Guid ProductId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ProductData Product { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Guid OrderId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderData Order { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public int Amount { get; set; }
        public decimal CurrencyValue { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
    }
}
