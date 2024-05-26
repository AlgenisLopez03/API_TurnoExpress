using GestorDeTurnos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class ServiceConfiguration : EntityBaseConfiguration<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.ServiceName).IsRequired().HasMaxLength(255);
            builder.Property(e => e.ServiceImage).HasMaxLength(255);
            builder.Property(e => e.Duration).IsRequired();
            builder.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(e => e.Establishment)
                   .WithMany(e => e.Services)
                   .HasForeignKey(e => e.EstablishmentId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}