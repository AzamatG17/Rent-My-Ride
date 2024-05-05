using Microsoft.EntityFrameworkCore;
using RendMyRide.DataAccess;

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
    }
}
