using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ModuleRouteAttribute : RouteAttribute
    {
        public ModuleRouteAttribute(string template)
            : base($"api/[module]/{template}")
        {
        }
    }
}
