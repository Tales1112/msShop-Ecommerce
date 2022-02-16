using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using mShop.WEbApi.Core.Usuario;
using msShop.Extensions;
using msShop.Funcoes;
using msShop.Funcoes.Frete;
using msShop.Funcoes.PagSeguro;
using msShop.Models;
using msShop.Services;
using msShop.Services.Handlers;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Net.Http;
using WSCorreios;
using static msShop.Extensions.CpfAnnotation;

namespace msShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
      
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString
            ("ConexaoPadrao")));
            services.Configure<AppSettings>(Configuration);
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/erro/403";
                });
            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddSingleton<IValidationAttributeAdapterProvider, CpfValidationAttributeAdapterProvider>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddRazorPages();
            services.AddSession();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<ShoppingCart>(sc => ShoppingCart.GetCart(sc));
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<WSCorreiosCalcularFrete>();
            services.AddScoped<CalculoPacote>();
            services.AddScoped<CartaoCredito>();
            services.AddScoped<CartaoCreditoBLL>();
            services.AddScoped<DadosUsuarioBLL>();
            services.AddScoped<PagSeguroBLL>();

            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>()
                .AddPolicyHandler(PollyExtensions.EsperarTentar())
                .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            services.AddScoped<CalcPrecoPrazoWSSoap>(options =>
            {
                var servico = new CalcPrecoPrazoWSSoapClient(CalcPrecoPrazoWSSoapClient.EndpointConfiguration.CalcPrecoPrazoWSSoap);
                return servico;
            });
            services.AddScoped<FuncoesBase>();
            services.AddHttpContextAccessor();
            services.AddSession();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();

            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Home}/{Action=Index}/{id?}"
                    );

                endpoints.MapRazorPages();
            });
        }
    }
    public static class PollyExtensions
    {
        public static AsyncRetryPolicy<HttpResponseMessage> EsperarTentar()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"Tentando pela {retryCount} vez!");
                    Console.ForegroundColor = ConsoleColor.White;
                });

            return retry;
        }
    }
}
