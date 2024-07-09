using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class AppointmentConfiguration : EntityBaseConfiguration<Appointment>
    {
        public override void Configure(EntityTypeBuilder<Appointment> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Position).IsRequired();
            builder.Property(e => e.Date)
                    .HasColumnType("datetime")
                   .HasDefaultValueSql("GetDate()")
                   .IsRequired();

            builder.HasOne(e => e.Establishment)
                   .WithMany(e => e.Appointments)
                   .HasForeignKey(e => e.EstablishmentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Employee)
                   .WithMany(e => e.Appointments)
                   .HasForeignKey(a => a.EmployeeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Service)
                   .WithMany(e => e.Appointments)
                   .HasForeignKey(e => e.ServiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Status)
                    .WithMany(e => e.Appointments)
                    .HasForeignKey(e => e.StatusId)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}