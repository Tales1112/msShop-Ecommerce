using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace mShop.WEbApi.Core.Identidade
{
    public static class JwtConfig
    {
        public static void AddJwtConfiguration(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
        }
    }
}
