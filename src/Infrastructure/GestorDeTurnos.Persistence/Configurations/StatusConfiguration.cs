using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.Seeds;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class StatusConfiguration : EntityBaseConfiguration<Status>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name).IsRequired();

            builder.HasData(StatusSeed.DefaultValues);
           
        }
    }
}