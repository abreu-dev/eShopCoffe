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

            builder.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(UserData.LoginMaxLength);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(UserData.PasswordMaxLength);

            builder.Property(x => x.IsAdmin);

            builder.Property(x => x.LastAccess);
        }
    }
}
