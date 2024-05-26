using GestorDeTurnos.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public abstract class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(entity => entity.CreatedBy)
                  .HasColumnType("nvarchar(25)")
                  .HasDefaultValue("System")
                  .IsRequired();

            builder.Property(entity => entity.Created)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("GetDate()")
                   .IsRequired();

            builder.Property(entity => entity.LastModifiedBy);

            builder.Property(entity => entity.LastModified);
        }
    }
}