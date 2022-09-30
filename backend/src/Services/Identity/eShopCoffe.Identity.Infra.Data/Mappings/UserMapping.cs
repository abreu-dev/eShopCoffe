using eShopCoffe.Identity.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCoffe.Identity.Infra.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserData>
    {
        public void Configure(EntityTypeBuilder<UserData> builder)
        {
            builder.ToTable(UserData.TableName);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(UserData.UsernameMaxLength);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(UserData.EmailMaxLength);

            builder.Property(x => x.HashedPassword)
                .IsRequired();

            builder.Property(x => x.IsAdmin);

            builder.Property(x => x.LastAccess);
        }
    }
}
