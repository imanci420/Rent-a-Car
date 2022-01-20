using Microsoft.Extensions.DependencyInjection;
using RentACar.Interfaces;
using RentACar.Services;

namespace RentACar.DependencyInjection
{
    public static class ConfigureServicesInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<HashService>();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IRentService, RentService>();
            services.AddScoped<ICommentService, CommentService>();

            return services;
        }
    }
}
