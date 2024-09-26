using KutuphaneProjesi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KutuphaneProjesi.Infrastructure.EntityTypeConfig
{
    public class RoleConfig : BaseEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(u => u.Name)
                .IsRequired();

            var userRole = new Role
            {
                Id = Guid.Parse("1E5F19F8-43B0-45FE-B276-F37D9A6541D8"),
                Name = "user",
            };

            var adminRole = new Role
            {
                Id = Guid.Parse("66D20726-5805-4468-86F2-63AE89D402C1"),
                Name = "admin",
            };

            builder.HasData(userRole, adminRole);

            base.Configure(builder);
        }
    }
}
