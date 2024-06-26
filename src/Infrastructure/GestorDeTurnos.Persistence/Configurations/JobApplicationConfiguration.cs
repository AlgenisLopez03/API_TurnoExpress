
using GestorDeTurnos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class JobApplicationConfiguration : EntityBaseConfiguration<JobApplication>
    {
        public override void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            base.Configure(builder);

            builder.Property(j => j.Status).IsRequired();

            builder.HasOne(j => j.Establishment)
                   .WithMany()
                   .HasForeignKey(j => j.EstablishmentId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(j => j.Role)
                   .WithMany()
                   .HasForeignKey(j => j.RoleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
