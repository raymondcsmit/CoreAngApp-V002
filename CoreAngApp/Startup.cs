using Core;
using Core.Contracts;
using Core.Insfrastructure;
using Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.IO;

namespace CoreAngApp
{
	public class Startup
	{
		private readonly IWebHostEnvironment WebHostEnv;
		private IList<PluginInfo> _plugins;
		public Startup(IWebHostEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{Environments.Development}.json", optional: true);

			if (env.IsDevelopment())
			{
				// For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
				builder.AddUserSecrets<Startup>();
			}

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
			WebHostEnv = env;
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<IConfigurationRoot>(Configuration);
			services.Configure<Tenant>(Configuration.GetSection("Tenant"));
			services.AddSingleton(sp =>
			{
				var tenant = sp.GetService<IOptions<Tenant>>().Value;
				string appMode = Configuration.GetSection("AppMode").Value;
				tenant.AppMode = appMode;
				return tenant;
			});
			var optionsBuilder = new CoreDbContextOptionsBuilder(Configuration);
			services.AddSingleton<CoreDbContextOptionsBuilder>(optionsBuilder);

			string rootPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules");
			_plugins = new PluginManager().LoadPlugins(rootPath);
			var pluginStartups = services.AddPlugins(_plugins);
			services.AddSingleton<IEnumerable<IPluginStartup>>(pluginStartups);

			//string rootPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules");
			//_plugins = new PluginManager().LoadPlugins(rootPath);
			//services.AddPlugins(_plugins);
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll",
					builder =>
					{
						builder.AllowAnyOrigin()
							   .AllowAnyMethod()
							   .AllowAnyHeader();
					});
			});
			services.AddControllersWithViews();
			//services.AddSpaStaticFiles(configuration =>
			//{
			//    configuration.RootPath = "ClientApp/dist";
			//});
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "HostApp", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors("AllowAll");
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AngCoreApp v1"));
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}


			app.UseHttpsRedirection();
			app.UseStaticFiles(new StaticFileOptions()
			{
				OnPrepareResponse = (context) =>
				{
					// Retrieve Cache configuration from appsettings.json
					context.Context.Response.Headers["Cache-Control"] = Configuration["StaticFiles:Headers:Cache-Control"];
				}

			});
			//if (!env.IsDevelopment())
			//{
			//    app.UseSpaStaticFiles();
			//}
			app.UseRouting();
			var pluginStartups = app.ApplicationServices.GetRequiredService<IEnumerable<IPluginStartup>>();
			foreach (var pluginStartup in pluginStartups)
			{
				pluginStartup.Configure(app, env);
			}
			var modules = app.ApplicationServices.GetServices<IPluginStartup>();
			foreach (var module in modules)
			{
				app.Map($"/{module.RoutePrefix}", moduleApp =>
				{
					moduleApp.UseRouting();

					moduleApp.UseEndpoints(endpoints =>
					{
						// Set up module-specific controller routes
						endpoints.MapControllerRoute(
							name: $"module_{module.RoutePrefix}",
							pattern: $"{module.RoutePrefix}/{{controller=Home}}/{{action=Index}}/{{id?}}");
					});

					// Configure module-specific middleware
					moduleApp.Use(next => context =>
					{
						// ...
						return next(context);
					});
				});
			}
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "api",
					pattern: "api/{controller}/{action}/{id?}");
			});
			//app.MapWhen(context => !context.Request.Path.StartsWithSegments("/api"), builder =>
			//{
			//    builder.UseStaticFiles();
			//    builder.UseSpa(spa =>
			//    {
			//        spa.Options.SourcePath = "ClientApp";

			//        if (env.IsDevelopment())
			//        {
			//            spa.UseAngularCliServer(npmScript: "start");
			//        }
			//    });
			//});
		}
	}
}
