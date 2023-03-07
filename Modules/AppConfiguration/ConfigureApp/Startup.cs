using Core.Contracts;
using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConfigureApp.Infrastructure;

namespace ConfigureApp
{
    public class Startup : PluginStartupBase
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        private readonly IConfigurationRoot config;
        public Startup(CoreDbContextOptionsBuilder optb, IConfigurationRoot _config)
        {
            OptionsBuilder = optb;
            config = _config;
            RoutePrefix = "ConfigurationApp";
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ConfigureAppDbContext>(options => OptionsBuilder.SelectDatabase<ConfigureAppDbContext>());
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuditLogEventHandler).Assembly));
            services.AddControllers();
        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}