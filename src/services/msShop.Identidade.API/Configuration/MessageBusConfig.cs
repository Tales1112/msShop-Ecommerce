using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mShop.Core.Utils;
using mShop.MessageBus;

namespace msShop.Identidade.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}
