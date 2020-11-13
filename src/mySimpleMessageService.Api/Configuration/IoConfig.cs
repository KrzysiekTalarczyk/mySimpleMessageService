using Microsoft.Extensions.DependencyInjection;
using mySimpleMessageService.Application.Contacts;
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
            services.AddScoped<IContactService, ContactService>();
            return services;
        }
    }
}
