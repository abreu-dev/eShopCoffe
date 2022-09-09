using eShopCoffe.Basket.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCoffe.Basket.Infra.Data.Mappings
{
    public class BasketItemMapping : IEntityTypeConfiguration<BasketItemData>
    {
        public void Configure(EntityTypeBuilder<BasketItemData> builder)
        {
            builder.ToTable(BasketItemData.TableName);

            builder.Property(x => x.Amount)
                .IsRequired();

            builder.HasOne(x => x.Basket)
                .WithMany(x => x.Items);
        }
    }
}
