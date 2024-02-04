using Core;
using Core.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationApp
{
	public class Startup : PluginStartupBase
	{
		private readonly CoreDbContextOptionsBuilder OptionsBuilder;
		private readonly IConfigurationRoot config;
		public Startup(CoreDbContextOptionsBuilder optb, IConfigurationRoot _config)
		{
			OptionsBuilder = optb;
			config = _config;
			RoutePrefix = "SignalR";
			IsSignalR = true;
		}
		public override void ConfigureServices(IServiceCollection services)
		{
			//services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SendEmailEventHandler).Assembly));
			services.AddSignalR();
		}

		public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapHub<NotificationHub>("signalr/notification-hub");
				// Map other endpoints like MVC controllers or Razor Pages
			});
			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapControllers();
			//});
		}
	}
}
