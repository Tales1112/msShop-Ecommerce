using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using mShop.Core.Mediator;
using mShop.WEbApi.Core.Usuario;
using msShop.Cliente.API.Application.Commands;
using msShop.Cliente.API.Application.Commands.Handlers;
using msShop.Cliente.API.Application.Events;
using msShop.Cliente.API.Data;
using msShop.Cliente.API.Data.Repository;

namespace msShop.Cliente.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IClienteRepository,ClienteRepository>();
            services.AddScoped<ClientesContext>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarEnderecoCommand,ValidationResult>, ClienteCommandHandler>();
        }
    }
}
