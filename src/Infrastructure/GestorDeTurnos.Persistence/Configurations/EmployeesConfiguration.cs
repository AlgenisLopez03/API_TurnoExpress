
using GestorDeTurnos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class EmployeesConfiguration : EntityBaseConfiguration<Employees>
    {
        public override void Configure(EntityTypeBuilder<Employees> builder)
        {
            base.Configure(builder);

            builder.HasMany(e => e.EstablishmentRoles)
                   .WithMany(er => er.Employees)
                    .UsingEntity(j => j.ToTable("EmployeeEstablishmentRoles"));

            builder.HasOne(e => e.Establishment)
                   .WithMany()
                   .HasForeignKey(e => e.EstablishmentId)
                   .IsRequired();

            builder.HasMany(e => e.Services)
                   .WithMany(s => s.Employees)
                   .UsingEntity(j => j.ToTable("EmployeeServices"));
        }
    }
}
