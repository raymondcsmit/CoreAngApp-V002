using Microsoft.AspNetCore.Http;
using Serilog.Events;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngApp.Middleware
{
	public class SerilogMiddleware
	{
		private const string MessageTemplate =
			"HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

		// Fixed: Use Serilog's ILogger instead of Microsoft.Extensions.Logging.ILogger
		private static readonly Serilog.ILogger Log = Serilog.Log.ForContext<SerilogMiddleware>();

		private readonly RequestDelegate _next;

		public SerilogMiddleware(RequestDelegate next)
		{
			_next = next ?? throw new ArgumentNullException(nameof(next));
		}

		public async Task Invoke(HttpContext httpContext)
		{
			if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

			var sw = Stopwatch.StartNew();

			try
			{
				await _next(httpContext);
			}
			finally // Changed from catch to finally to ensure logging occurs whether or not an exception is thrown
			{
				sw.Stop();

				var statusCode = httpContext.Response?.StatusCode;
				var level = statusCode >= 500 ? LogEventLevel.Error : LogEventLevel.Information; // Fixed: Use >= for status code check

				var logContext = httpContext.Response.StatusCode >= 500 ? LogForErrorContext(httpContext) : Log;
				logContext.Write(level, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, statusCode, sw.Elapsed.TotalMilliseconds);
			}
		}

		private static bool LogException(HttpContext httpContext, Stopwatch sw, Exception ex)
		{
			sw.Stop();

			LogForErrorContext(httpContext)
				.Error(ex, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, 500, sw.Elapsed.TotalMilliseconds);

			return false; // This indicates that this catch block should not handle the exception, allowing it to propagate.
		}

		private static Serilog.ILogger LogForErrorContext(HttpContext httpContext)
		{
			var request = httpContext.Request;

			var result = Log
				.ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), destructureObjects: true)
				.ForContext("RequestHost", request.Host.ToString())
				.ForContext("RequestProtocol", request.Protocol);

			if (request.HasFormContentType && request.Form != null) // Added null check for request.Form
			{
				result = result.ForContext("RequestForm", request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));
			}

			return result;
		}
	}
}
