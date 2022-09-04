using eShopCoffe.Catalog.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCoffe.Catalog.Infra.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<ProductData>
    {
        public void Configure(EntityTypeBuilder<ProductData> builder)
        {
            builder.ToTable(ProductData.TableName);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.QuantityAvailable)
                .IsRequired();
        }
    }
}
