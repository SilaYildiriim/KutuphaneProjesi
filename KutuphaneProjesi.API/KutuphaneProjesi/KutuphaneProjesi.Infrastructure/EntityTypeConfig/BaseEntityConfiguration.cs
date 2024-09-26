using KutuphaneProjesi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneProjesi.Infrastructure.EntityTypeConfig
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class, IBaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired(false);
            builder.Property(x => x.UpdatedDate).IsRequired(false);
            builder.Property(x => x.Status).IsRequired(false);
        }
    }
}
