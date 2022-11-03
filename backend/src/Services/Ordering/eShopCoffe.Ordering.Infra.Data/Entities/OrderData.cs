using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Identity.Infra.Data.Entities;
using eShopCoffe.Ordering.Domain.Enums;

namespace eShopCoffe.Ordering.Infra.Data.Entities
{
    public class OrderData : EntityData
    {
        public static string TableName => "Order";

        public Guid UserId { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UserData User { get; set; }

        public string Cep { get; set; } = string.Empty;
        public static int CepMaxLength => 100;

        public string? Number { get; set; }
        public static int NumberMaxLength => 10;

        public OrderStatus Status { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal CurrencyValue { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;

        public ICollection<OrderEventData> Events { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ICollection<OrderItemData> Items { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
