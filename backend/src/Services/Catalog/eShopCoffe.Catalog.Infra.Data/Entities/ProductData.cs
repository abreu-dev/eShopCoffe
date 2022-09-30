using eShopCoffe.Core.Data.Entities;

namespace eShopCoffe.Catalog.Infra.Data.Entities
{
    public class ProductData : EntityData
    {
        public static string TableName => "Product";

        public string Name { get; set; } = string.Empty;
        public static int NameMaxLength => 100;

        public string Description { get; set; } = string.Empty;
        public static int DescriptionMaxLength => 100;

        public string ImageUrl { get; set; } = string.Empty;

        public int QuantityAvailable { get; set; }

        public decimal CurrencyValue { get; set; }

        public string CurrencyCode { get; set; } = string.Empty;
    }
}
