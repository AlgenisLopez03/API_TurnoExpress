using GestorDeTurnos.Application.Configs;
using GestorDeTurnos.Application.Interfaces.Services;
using GestorDeTurnos.Application.Wrappers;
using GestorDeTurnos.Identity.DbContext;
using GestorDeTurnos.Identity.Models;
using GestorDeTurnos.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace GestorDeTurnos.Identity
{
    public static class ServiceExtensions
    {
        public static void AddIdentityLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region DbContext

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<IdentityContext>(option =>
                {
                    option.UseInMemoryDatabase("IdentityDb");
                });
            }
            else
            {
                services.AddDbContext<IdentityContext>(option =>
                {
                    option.UseSqlServer(configuration.GetConnectionString("GDTIdentityConnection"),
                        optionAction => optionAction.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
                });
            }

            #endregion DbContext

            #region Configure

            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            #endregion Configure

            #region Identity

            services.AddIdentity<CustomIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            #endregion Identity

            #region Dependency injection

            services.AddScoped<IAccountService, AccountService>();

            #endregion Dependency injection

            #region Authentication

            var key = Encoding.UTF8.GetBytes(configuration["JwtConfig:key"]);
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = configuration["JwtConfig:Audience"],
                    ValidIssuer = configuration["JwtConfig:Issuer"],
                };
                options.Events = new JwtBearerEvents()
                {
                    OnChallenge = async (context) =>
                    {
                        var statusCode = StatusCodes.Status401Unauthorized;
                        context.Response.StatusCode = statusCode;
                        context.HandleResponse();

                        var response = new ApiResponse(statusCode, "You are not authenticated");

                        await context.Response.WriteAsJsonAsync(response);
                    },
                    OnForbidden = async (context) =>
                    {
                        var statusCode = StatusCodes.Status403Forbidden;
                        context.Response.StatusCode = statusCode;
                        context.Response.ContentType = "application/json";

                        var response = new ApiResponse(statusCode, "You are not authorized to access this resource");
                        await context.Response.WriteAsJsonAsync(response);
                    }
                };
            });

            #endregion Authentication
        }
    }
}