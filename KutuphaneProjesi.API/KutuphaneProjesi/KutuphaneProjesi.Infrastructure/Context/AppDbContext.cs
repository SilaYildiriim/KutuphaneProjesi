using KutuphaneProjesi.Domain.Entities;
using KutuphaneProjesi.Infrastructure.EntityTypeConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneProjesi.Infrastructure.Context
{

    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=YourServer;Database=KutuphaneProjesiDB;Uid=YourUserName;Pwd=YourPassword; TrustServerCertificate = True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig())
                   .ApplyConfiguration(new RoleConfig())
                   .ApplyConfiguration(new UserRoleConfig())
                   .ApplyConfiguration(new BookConfig());

            base.OnModelCreating(builder);
        }
    }
}
