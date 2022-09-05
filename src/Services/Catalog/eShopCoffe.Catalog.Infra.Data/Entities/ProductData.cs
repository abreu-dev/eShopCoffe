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

        public int QuantityAvailable { get; set; }
    }
}
