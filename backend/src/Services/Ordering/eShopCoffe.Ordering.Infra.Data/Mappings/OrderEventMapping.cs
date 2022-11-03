using eShopCoffe.Ordering.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCoffe.Ordering.Infra.Data.Mappings
{
    public class OrderEventMapping : IEntityTypeConfiguration<OrderEventData>
    {
        public void Configure(EntityTypeBuilder<OrderEventData> builder)
        {
            builder.ToTable(OrderEventData.TableName);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.HasOne(x => x.Order)
                .WithMany(x => x.Events);
        }
    }
}
