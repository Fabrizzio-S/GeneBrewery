using GeneBrewery.Business.BeerProviders;
using GeneBrewery.Business.Beers;
using GeneBrewery.Business.Breweries;
using GeneBrewery.Business.Common;
using GeneBrewery.Business.Providers;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Newtonsoft.Json;

namespace GeneBrewery.Api
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
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddScoped(_ => new BreweryContext(Configuration.GetConnectionString("GeneBreweryConnectionString"), true));
            services.AddTransient<IBreweryRepository, BreweryRepository>();
            services.AddTransient<IProviderRepository, ProviderRepository>();
            services.AddTransient<IBeerRepository, BeerRepository>();
            services.AddTransient<IBeerProviderRepository, BeerProviderRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
