using eShopCoffe.Basket.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCoffe.Basket.Infra.Data.Mappings
{
    public class BasketMapping : IEntityTypeConfiguration<BasketData>
    {
        public void Configure(EntityTypeBuilder<BasketData> builder)
        {
            builder.ToTable(BasketData.TableName);
        }
    }
}
