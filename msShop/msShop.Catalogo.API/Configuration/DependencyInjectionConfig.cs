using Microsoft.Extensions.DependencyInjection;
using msShop.Catalogo.API.Data;
using msShop.Catalogo.API.Data.Repository;

namespace msShop.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<CatalogoContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
        }
    }
}
