
using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.Seeds;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class EstablishmentRolesConfiguration : EntityBaseConfiguration<EstablishmentRoles>
    {
        public override void Configure(EntityTypeBuilder<EstablishmentRoles> builder)
        {
            base.Configure(builder);

            builder.Property(er => er.RoleName).IsRequired();

            builder.HasOne(er => er.EstablishmentType)
                   .WithMany(et => et.EstablishmentRoles)
                   .HasForeignKey(er => er.EstablishmentTypeId)
                   .IsRequired();

            builder.HasData(EstablishmentRolesSeed.DefaultValues);
        }
    }
}
