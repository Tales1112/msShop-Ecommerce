using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mShop.WEbApi.Core.Usuario;
using msShop.Identidade.API.Services;
using NetDevPack.Security.Jwt.AspNetCore;

namespace msShop.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<AuthenticationService>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            return services;
        }

        public static  IApplicationBuilder UserApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseJwksDiscovery();
            return app;
        }
    }
}
