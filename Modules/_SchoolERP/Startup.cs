using Core;
using Core.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SchoolERP.Data;

namespace SchoolERP
{
    public class Startup : PluginStartupBase
    {
        private readonly CoreDbContextOptionsBuilder OptionsBuilder;
        public Startup(CoreDbContextOptionsBuilder optb)
        {
            OptionsBuilder = optb;
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SCDbContext>(options => OptionsBuilder.SelectDatabase<SCDbContext>());

        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}