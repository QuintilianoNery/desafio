using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PooLojaVirtual.Core;
using PooLojaVirtual.Infraestructure;
using PooLojaVirtual.Services;
using Microsoft.EntityFrameworkCore;

namespace PooLojaVirtual
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<DbContextOptions<LojaDbContext>>();

            var connectionString = _configuration.GetConnectionString("LojaDbContext");

            if (_environment.IsDevelopment())
            {
                services.AddDbContext<LojaDbContext, LojaSqLiteDbContext>(options =>
                    options.UseSqlite(connectionString));
            }
            else
            {
                services.AddDbContext<LojaDbContext>(options =>
                    options.UseSqlServer(connectionString));
            }

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc();
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
            services.AddScoped<IGerenciadorCarrinho, GerenciadorCarrinho>();
            services.AddScoped<IServicoEmail, ServicoEmail>();
            services.AddScoped<IPedidoService, PedidoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
