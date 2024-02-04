﻿using AuditLog.Application.Events.Handler;
using Core;
using Core.Contracts;
using EmailApp.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmailApp
{

	public class Startup : PluginStartupBase
	{
		private readonly CoreDbContextOptionsBuilder OptionsBuilder;
		private readonly IConfigurationRoot config;
		public Startup(CoreDbContextOptionsBuilder optb, IConfigurationRoot _config)
		{
			OptionsBuilder = optb;
			config = _config;
			RoutePrefix = "Email";
		}
		public override void ConfigureServices(IServiceCollection services)
		{
			var emailConfig = config.GetSection("EmailConfiguration").Get<EmailConfiguration>()
					  ?? throw new InvalidOperationException("Email configuration is required.");

			services.AddSingleton(emailConfig);
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SendEmailEventHandler).Assembly));
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
