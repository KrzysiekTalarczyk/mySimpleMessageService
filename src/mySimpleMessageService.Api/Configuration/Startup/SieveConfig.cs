using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Models;
using Sieve.Services;

namespace mySimpleMessageService.Api.Configuration.Startup
{
    public static class SieveConfig
    {
        public static IServiceCollection RegisterSieveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISieveProcessor, SieveProcessorConfig>();
            services.Configure<SieveOptions>(configuration.GetSection("Sieve"));
            return services;
        }
    }
}
