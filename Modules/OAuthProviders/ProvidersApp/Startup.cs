using Core;
using Core.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Providers.Application;
using Providers.Application.Queries.Handler;
using Providers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvidersApp
{
    public class Startup : PluginStartupBase
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        private readonly IConfigurationRoot config;
        public Startup(CoreDbContextOptionsBuilder optb, IConfigurationRoot _config)
        {
            OptionsBuilder = optb;
            config = _config;
            RoutePrefix = "ProvidersApp";
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProviderContext>(options => OptionsBuilder.SelectDatabase<ProviderContext>());
            services.AddTransient<OAuth2ProviderFactory>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProvidersQueryHandler).Assembly));
            services.AddControllers();

        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ProviderContext>();
                //DbInitializer.Initialize(context);
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
