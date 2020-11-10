using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mySimpleMessageService.Application.Filtering;
using Sieve.Models;
using Sieve.Services;

namespace mySimpleMessageService.Api.Configuration
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
