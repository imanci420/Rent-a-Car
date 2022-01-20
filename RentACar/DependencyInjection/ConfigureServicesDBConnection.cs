using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACar.DataAccess;

namespace RentACar.DependencyInjection
{
    public static class ConfigureServicesDBConnection
    {
        public static IServiceCollection AddDBConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RentACarDBContext>(
                options => options.UseNpgsql(configuration["DBConnection:ConnectionString"]));

            return services;
        }
    }
}
