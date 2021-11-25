using ExemploSonar.API.Interfaces.Repositories;
using ExemploSonar.API.Interfaces.Services;
using ExemploSonar.API.Repositories;
using ExemploSonar.API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploSonar.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {

            services.AddScoped<IRegistroRepository, RegistroRepository>();

            services.AddScoped<IRegistroService, RegistroService>();

            return services;
        }
    }
}
