using AuditLog.Application.Events.Handler;
using AuditLog.Infrastructure;
using Core;
using Core.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuditLog
{
    public class Startup : PluginStartupBase
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        private readonly IConfigurationRoot config;
        public Startup(CoreDbContextOptionsBuilder optb, IConfigurationRoot _config)
        {
            OptionsBuilder = optb;
            config = _config;
            RoutePrefix = "AuditLog";
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AuditLogContext>(options => OptionsBuilder.SelectDatabase<AuditLogContext>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AuditLogEventHandler).Assembly));
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