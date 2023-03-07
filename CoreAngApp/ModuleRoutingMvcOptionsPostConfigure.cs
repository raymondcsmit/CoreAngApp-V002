using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CoreAngApp
{
    public class ModuleRoutingMvcOptionsPostConfigure : IPostConfigureOptions<MvcOptions>
    {
        private readonly IEnumerable<Module> _modules;

        public ModuleRoutingMvcOptionsPostConfigure(IEnumerable<Module> modules)
        {
            _modules = modules;
        }

        public void PostConfigure(string name, MvcOptions options)
        {
            options.Conventions.Add(new ModuleRoutingConvention(_modules));
        }
    }
    public class ModuleRoutingConvention : IActionModelConvention
    {
        private readonly IEnumerable<Module> _modules;

        public ModuleRoutingConvention(IEnumerable<Module> modules)
        {
            _modules = modules;
        }

        public void Apply(ActionModel action)
        {
            var module = _modules.FirstOrDefault(m => m.Assembly == action.Controller.ControllerType.Assembly);
            if (module == null)
            {
                return;
            }

            action.RouteValues.Add("module", module.RoutePrefix);
        }
    }
    public class Module
    {
        /// <summary>
        /// Gets the route prefix to all controller and endpoints in the module.
        /// </summary>
        public string RoutePrefix { get; }

        /// <summary>
        /// Gets the startup class of the module.
        /// </summary>
        public IStartup Startup { get; }

        /// <summary>
        /// Gets the assembly of the module.
        /// </summary>
        public Assembly Assembly => Startup.GetType().Assembly;

        public object Name { get; internal set; }

        public Module(string routePrefix, IStartup startup)
        {
            RoutePrefix = routePrefix;
            Startup = startup;
        }
    }
}
