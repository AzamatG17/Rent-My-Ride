using Microsoft.EntityFrameworkCore;
using RendMyRide.DataAccess;
using RendMyRide.DataAccess.Repository;
using RendMyRide.Domain.Interfaces.Auth;
using RendMyRide.Domain.Interfaces.JwtTokenGenerate;
using RendMyRide.Domain.Interfaces.Repositories;
using RendMyRide.Domain.Interfaces.Services;
using RendMyRide.Domain.Models;
using RendMyRide.Infrastructure.JwtToken;
using RendMyRide.Infrastructure.PasswordHash;
using RendMyRide.Infrastructure.Services;
using Serilog;

namespace RendMyRide.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection service)
        {
            var builder = WebApplication.CreateBuilder();

            service.AddDbContext<RendMyRideDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RendMyRideConnection")));

            return service;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IUserRepository<User>, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddControllers()
              .AddNewtonsoftJson(options =>
                  options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
               );

            return services;
        }
    }
}
