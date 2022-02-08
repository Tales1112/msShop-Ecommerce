using Microsoft.Extensions.DependencyInjection;
using System;

namespace mShop.MessageBus
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrWhiteSpace(connection)) throw new ArgumentException();

            services.AddSingleton<IMessageBus>(new MessageBus(connection));

            return services;
        }
    }
}
