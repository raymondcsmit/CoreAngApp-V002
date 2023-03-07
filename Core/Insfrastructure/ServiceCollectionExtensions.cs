using Microsoft.Extensions.DependencyInjection;
using Core.Contracts;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace Core.Insfrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddPlugins(this IServiceCollection services, IList<PluginInfo> plugins)
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
