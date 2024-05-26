using GestorDeTurnos.Domain.Entities;
using GestorDeTurnos.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Persistence.Configurations
{
    public class ReviewConfiguration : EntityBaseConfiguration<Review>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Rating).IsRequired();
            builder.Property(e => e.Comment).HasMaxLength(1000);
            builder.Property(e => e.Date)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("GetDate()")
                   .IsRequired();

            builder.HasOne<CustomIdentityUser>()
                   .WithMany()
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Establishment)
                   .WithMany(e => e.Reviews)
                   .HasForeignKey(e => e.EstablishmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}