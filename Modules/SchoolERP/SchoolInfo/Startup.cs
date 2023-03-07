using Core.Contracts;
using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SchoolInfo.Module.Data;

namespace SchoolInfo.Module
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
            services.AddDbContext<SchoolInfoDbContext>(options => OptionsBuilder.SelectDatabase<SchoolInfoDbContext>());

        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}