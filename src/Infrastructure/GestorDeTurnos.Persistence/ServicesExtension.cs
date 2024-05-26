using GestorDeTurnos.Application.Interfaces.Repositories;
using GestorDeTurnos.Persistence.DbContexts;
using GestorDeTurnos.Persistence.Repositories;
using GestorDeTurnos.Persistence.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorDeTurnos.Persistence
{
    public static class ServicesExtension
    {
        public static void AddPersistenceLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext

            bool useInMemoryDatabase = configuration.GetValue<bool>("UseInMemoryDatabase");

            if (useInMemoryDatabase)
            {
                services.AddDbContext<ApplicationDbContext>(DbContextSetup.InMemoryOptions);
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(DbContextSetup.Configure(configuration));
            }

            #endregion DbContext

            #region Repositories

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();

            #endregion Repositories
        }
    }
}