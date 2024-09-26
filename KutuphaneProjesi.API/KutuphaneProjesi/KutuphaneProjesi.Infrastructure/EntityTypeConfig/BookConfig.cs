using KutuphaneProjesi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KutuphaneProjesi.Infrastructure.EntityTypeConfig
{
    public class BookConfig : BaseEntityConfiguration<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.AuthorName);

            builder.Property(b => b.Publisher);

            builder.Property(b => b.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(b => b.Image);

            base.Configure(builder);
        }
    }
}
