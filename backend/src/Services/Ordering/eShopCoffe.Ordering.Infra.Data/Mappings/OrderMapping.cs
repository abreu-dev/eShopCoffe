using eShopCoffe.Ordering.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCoffe.Ordering.Infra.Data.Mappings
{
    internal class OrderMapping : IEntityTypeConfiguration<OrderData>
    {
        public void Configure(EntityTypeBuilder<OrderData> builder)
        {
            builder.ToTable(OrderData.TableName);

            builder.Property(x => x.Cep)
                .IsRequired();

            builder.Property(x => x.Number);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.PaymentMethod)
                .IsRequired();
        }
    }
}
