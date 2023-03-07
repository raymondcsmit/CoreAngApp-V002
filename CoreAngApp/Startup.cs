using Core.Insfrastructure;
using Core.Models;
using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting.Server;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Channels;
using Core.Contracts;

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
            services.AddPlugins(_plugins);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));

            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist/ngx-admin";
            //});
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
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    OnPrepareResponse = (context) =>
            //    {
            //        // Retrieve Cache configuration from appsettings.json
            //        context.Context.Response.Headers["Cache-Control"] = Configuration["StaticFiles:Headers:Cache-Control"];
            //    }

            //});
            //app.UseStaticFiles();
            //if (!env.IsDevelopment())
            //{
            //    app.UseSpaStaticFiles();
            //}
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    // Retrieve Cache configuration from appsettings.json
                    context.Context.Response.Headers["Cache-Control"] = Configuration["StaticFiles:Headers:Cache-Control"];
                }

            });
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();
            //app.Map("/api", apiApp =>
            //{
            //    apiApp.UseRouting();
            //    apiApp.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapControllers();
            //    });
            //    // Add your API middleware and endpoints here
            //});

            // Set up module routes
            var modules = app.ApplicationServices.GetServices<IPluginStartup>();
            foreach (var module in modules)
            {
                app.Map($"/{module.RoutePrefix}", moduleApp =>
                {
                    moduleApp.UseRouting();

                    // Add module-specific services
                    //moduleApp.ConfigureServices(services);

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

            // Map requests to the Angular app to a different path
            app.MapWhen(context => !context.Request.Path.StartsWithSegments("/api"), builder =>
            {
                builder.UseStaticFiles();
                builder.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });
            });
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            //app.Map("/app", spaApp =>
            //{
            //    spaApp.UseSpa(spa =>
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
