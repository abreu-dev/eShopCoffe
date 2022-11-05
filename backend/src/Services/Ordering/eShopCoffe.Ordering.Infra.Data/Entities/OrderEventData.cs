using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Ordering.Domain.Enums;

namespace eShopCoffe.Ordering.Infra.Data.Entities
{
    public class OrderEventData : EntityData
    {
        public static string TableName => "OrderEvent";

        public Guid OrderId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public OrderData Order { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
    }
}
