using KutuphaneProjesi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KutuphaneProjesi.Infrastructure.EntityTypeConfig
{
    public class UserConfig : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.UserName)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();

            var user = new User
            {
                Id = Guid.Parse("5A2B12D5-B30D-4E67-B31F-5FE19A367485"),
                UserName = "user",
                Password = "password",
            };

            var admin = new User
            {
                Id = Guid.Parse("7CA69CFA-88FC-4569-AED2-A1BECAF4F9A6"),
                UserName = "admin",
                Password = "password",
            };

            builder.HasData(user, admin);
            base.Configure(builder);
        }
    }
}
