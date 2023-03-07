using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Contracts
{
    public interface IPluginStartup
    {
        string RoutePrefix { get; }

        void ConfigureServices(IServiceCollection services);

        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
