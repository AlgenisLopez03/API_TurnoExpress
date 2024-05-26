using GestorDeTurnos.Identity.Models;
using GestorDeTurnos.Identity.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorDeTurnos.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<CustomIdentityUser>
    {
        public void Configure(EntityTypeBuilder<CustomIdentityUser> builder)
        {
            builder.ToTable("Users");
            builder.HasData(UserSeed.DefaultValues);
        }
    }
}