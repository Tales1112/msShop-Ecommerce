using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mShop.Core.Utils;
using mShop.MessageBus;
using msShop.Cliente.API.Services;

namespace msShop.Cliente.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                    .AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}
