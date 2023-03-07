using Core;
using Core.Contracts;
using DataSyncApp.Application.Events.Handler;
using DataSyncApp.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataSyncApp
{
    public class Startup : PluginStartupBase
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        private readonly IConfigurationRoot config;
        public Startup(CoreDbContextOptionsBuilder optb, IConfigurationRoot _config)
        {
            OptionsBuilder = optb;
            config = _config;
            RoutePrefix = "DataSync";
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataSyncContext>(options => OptionsBuilder.SelectDatabase<DataSyncContext>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SyncDataEventHandler).Assembly));
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