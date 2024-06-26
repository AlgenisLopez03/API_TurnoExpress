
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.Seeds;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class EstablishmentTypesConfiguration : EntityBaseConfiguration<EstablishmentTypes>
    {
        public override void Configure(EntityTypeBuilder<EstablishmentTypes> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.TypeName).IsRequired();

            builder.HasMany(et => et.EstablishmentRoles)
                   .WithOne(er => er.EstablishmentType)
                   .HasForeignKey(er => er.EstablishmentTypeId)
                   .IsRequired();

            builder.HasData(EstablishmentTypeSeed.DefaultValues);
        }
    }
}
