using Core.Contracts;
using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConfigureApp.Infrastructure;
using ConfigureApp.Application.Queries.Handler;
using ConfigureApp.Application.Queries;
using Core.Responses;
using MediatR;
using System.Text.Json.Serialization;

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
            //services.AddMediatR(typeof(GetAllApplicationQueryHandler).Assembly);
            //services.AddMediatR(GetAllApplicationQueryHandler);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllApplicationQueryHandler).Assembly));
            //services.AddTransient<IRequestHandler<GetAllApplicationQuery, ResponseResult>, GetAllApplicationQueryHandler>();
            //services.AddTransient<IRequestHandler<GetApplicationQuery, ResponseResult>, GetApplicationQueryHandler>();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            ///services.AddControllers();

        }

        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ConfigureAppDbContext>();
                DbInitializer.Initialize(context);
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}