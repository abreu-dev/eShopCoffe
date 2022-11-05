using eShopCoffe.Ordering.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCoffe.Ordering.Infra.Data.Mappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItemData>
    {
        public void Configure(EntityTypeBuilder<OrderItemData> builder)
        {
            builder.ToTable(OrderItemData.TableName);

            builder.Property(x => x.ProductId)
                .IsRequired();

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.Property(x => x.CurrencyValue)
                .IsRequired();

            builder.Property(x => x.CurrencyCode)
                .IsRequired();

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Items);
        }
    }
}
