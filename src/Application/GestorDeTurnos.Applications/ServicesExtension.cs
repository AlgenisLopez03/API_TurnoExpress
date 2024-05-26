using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Services;
using GestorDeTurnos.Application.Setups;
using GestorDeTurnos.Application.Setups.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorDeTurnos.Application
{
    public static class ServicesExtension
    {
        public static void AddApplicationLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApiVersioning(ApiVersionSetup.Configure)
                .AddApiExplorer(VersionedApiExplorerSetup.Configure);
            services.AddAuthorization();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddCors(CorsSetup.Configure);
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddSwaggerGen(SwaggerGenSetup.Configure);

            #region Dependency Injection

            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IEstablishmentService, EstablishmentService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IServiceService, ServiceService>();

            #endregion Dependency Injection
        }
    }
}