using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Contracts
{
    public class PluginStartupBase : IPluginStartup
    {
        public string RoutePrefix { get; set; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
