using KutuphaneProjesi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KutuphaneProjesi.Infrastructure.EntityTypeConfig
{
    public class UserRoleConfig : BaseEntityConfiguration<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {

            var userRole = new UserRole
            {
                UserId = Guid.Parse("5A2B12D5-B30D-4E67-B31F-5FE19A367485"),
                RoleId = Guid.Parse("1E5F19F8-43B0-45FE-B276-F37D9A6541D8"),
            };

            var adminRole = new UserRole
            {
                UserId = Guid.Parse("7CA69CFA-88FC-4569-AED2-A1BECAF4F9A6"),
                RoleId = Guid.Parse("66D20726-5805-4468-86F2-63AE89D402C1"),
            };

            builder.HasData(userRole, adminRole);
            base.Configure(builder);
        }
    }
}
