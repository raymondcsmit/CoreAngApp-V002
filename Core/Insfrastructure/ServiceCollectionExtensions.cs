using Microsoft.Extensions.DependencyInjection;
using Core.Contracts;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Core.Insfrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IList<IPluginStartup> AddPlugins(this IServiceCollection services, IList<PluginInfo> plugins)
        {
            var mvcBuilder = services.AddControllers();
            var pluginStartupInterfaceType = typeof(IPluginStartup);
            var optionsBuilder = services.BuildServiceProvider().GetRequiredService<CoreDbContextOptionsBuilder>();
            var config = services.BuildServiceProvider().GetRequiredService<IConfigurationRoot>();
            var pluginStartups = new List<IPluginStartup>();

            foreach (var module in plugins)
            {
                var partFactory = ApplicationPartFactory.GetApplicationPartFactory(module.Assembly);
                var applicationParts = partFactory.GetApplicationParts(module.Assembly);
                foreach (var part in applicationParts)
                {
                    mvcBuilder.PartManager.ApplicationParts.Add(part);
                }

                var pluginStartupType = module.Assembly.GetTypes().FirstOrDefault(x => pluginStartupInterfaceType.IsAssignableFrom(x));

                if (pluginStartupType != null && pluginStartupType != pluginStartupInterfaceType)
                {
                    var moduleInitializer = Activator.CreateInstance(pluginStartupType, optionsBuilder, config) as IPluginStartup;

                    moduleInitializer.ConfigureServices(services);
                    pluginStartups.Add(moduleInitializer); // Add the plugin startup instance to the list
                }
            }

            return pluginStartups; // Return the list of plugin startup instances
        }

        public static IMvcBuilder AddPlugins2(this IServiceCollection services, IList<PluginInfo> plugins, IApplicationBuilder app, IWebHostEnvironment env)
        {
            var mvcBuilder = services.AddControllers();//.AddControllersWithViews();

            var pluginStartupInterfaceType = typeof(IPluginStartup);
            var optionsBuilder = services.BuildServiceProvider().GetRequiredService<CoreDbContextOptionsBuilder>();
            var config = services.BuildServiceProvider().GetRequiredService<IConfigurationRoot>();
            foreach (var module in plugins)
            {
                var partFactory = ApplicationPartFactory.GetApplicationPartFactory(module.Assembly);
                var applicationParts = partFactory.GetApplicationParts(module.Assembly);

                foreach (var part in applicationParts)
                {
                    mvcBuilder.PartManager.ApplicationParts.Add(part);
                }

                var pluginStartupType = module.Assembly.GetTypes().FirstOrDefault(x => pluginStartupInterfaceType.IsAssignableFrom(x));
                if (pluginStartupType != null && pluginStartupType != pluginStartupInterfaceType)
                {
                    var moduleInitializer = Activator.CreateInstance(pluginStartupType, optionsBuilder, config) as IPluginStartup;

                    moduleInitializer.ConfigureServices(services);
                    moduleInitializer.Configure(app, env);
                }
            }

            return mvcBuilder;
        }

        public static IMvcBuilder AddPlugins1(this IServiceCollection services, IList<PluginInfo> plugins)
        {
            var mvcBuilder = services.AddControllers();//.AddControllersWithViews();
            
            var pluginStartupInterfaceType = typeof(IPluginStartup);
            var optionsBuilder = services.BuildServiceProvider().GetRequiredService<CoreDbContextOptionsBuilder>();

            foreach (var module in plugins)
            {
                mvcBuilder.AddApplicationPart(module.Assembly);

                var pluginStartupType = module.Assembly.GetTypes().FirstOrDefault(x => pluginStartupInterfaceType.IsAssignableFrom(x));
                if (pluginStartupType != null && pluginStartupType != pluginStartupInterfaceType)
                {
                    var moduleInitializer = Activator.CreateInstance(pluginStartupType, optionsBuilder) as IPluginStartup;

                    //var moduleInitializer = Activator.CreateInstance(pluginStartupType) as IPluginStartup;
                    moduleInitializer.ConfigureServices(services);
                    
                }
            }

            return mvcBuilder;
        }
    }
}
