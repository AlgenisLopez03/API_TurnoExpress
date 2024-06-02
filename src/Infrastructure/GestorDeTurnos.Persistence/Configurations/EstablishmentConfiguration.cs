using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class EstablishmentConfiguration : EntityBaseConfiguration<Establishment>
    {
        public override void Configure(EntityTypeBuilder<Establishment> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.BusinessName).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Location).IsRequired().HasMaxLength(255);
            builder.Property(e => e.WorkingHours).IsRequired().HasMaxLength(255);
            builder.Property(e => e.Description).HasMaxLength(1000);
            builder.Property(e => e.ProfileImage).HasMaxLength(255);

            /*builder.HasOne<CustomIdentityUser>()
                   .WithMany()
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
            */
        }
    }
}