using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using msShop.Identidade.API.Data;
using msShop.Identidade.API.Extensions;
using msShop.Identidade.API.Model;
using NetDevPack.Security.Jwt;
using NetDevPack.Security.Jwt.Store.EntityFrameworkCore;

namespace msShop.Identidade.API.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppTokenSettings");
            services.Configure<AppTokenSettings>(appSettingsSection);

            services.AddJwksManager(options => options.Jws = JwsAlgorithm.ES256)
            .PersistKeysToDatabaseStore<ApplicationDbContext>();
            services.AddAuthentication()
             .AddGoogle(options =>
             {
                 options.ClientId = "94512361248-ob642trtokt91g95o6c9udlnuijapros.apps.googleusercontent.com";
                 options.ClientSecret = "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";
             });

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<Usuario>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
