using GestorDeTurnos.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestorDeTurnos.Persistence.Setup
{
    public static class DbContextSetup
    {
        public static readonly Func<IConfiguration, Action<DbContextOptionsBuilder>> Configure = configuration =>
        {
            Action<DbContextOptionsBuilder> OptionsBuilder = (options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("GestorDeTurnosConnection"),
                    optionAction =>
                    {
                        optionAction.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                        optionAction.EnableRetryOnFailure();
                    });
            };

            return OptionsBuilder;
        };

        public static readonly Action<DbContextOptionsBuilder> InMemoryOptions = (options) =>
        {
            options.UseInMemoryDatabase("ApplicationDb");
        };
    }
}