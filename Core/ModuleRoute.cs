using Microsoft.AspNetCore.Mvc;
using System;

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
