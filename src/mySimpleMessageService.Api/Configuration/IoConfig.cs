using Microsoft.Extensions.DependencyInjection;
using mySimpleMessageService.Application.Interfaces;
using mySimpleMessageService.Persistence.Repositories;

namespace mySimpleMessageService.Api.Configuration
{
    public static class IoConfig
    {
        public static IServiceCollection RegisterIoDependencies(this IServiceCollection services)
        {
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();
            return services;
        }
    }
}
