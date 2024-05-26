using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReportConfiguration : EntityBaseConfiguration<Report>
{
    public override void Configure(EntityTypeBuilder<Report> builder)
    {
        base.Configure(builder);
        builder.Property(e => e.Date)
               .HasColumnType("datetime")
               .HasDefaultValueSql("GetDate()")
               .IsRequired();
        builder.Property(e => e.Revenue).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(e => e.AppointmentsCount).IsRequired();

        builder.HasOne(e => e.Establishment)
               .WithMany(e => e.Reports)
               .HasForeignKey(e => e.EstablishmentId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}