using Core.Models;
using Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SecurityApp.Application.Events;
using SecurityApp.Domain;
using System.Security.Claims;

namespace SecurityApp.Application.Command.Handler
{

	public class LogOutCommandHandler : IRequestHandler<LogOutCommand, ResponseResult>
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IHttpContextAccessor contextAccessor;
		private readonly IConfigurationRoot _configuration;
		private readonly IMediator _mediator;
		private readonly Tenant _tenant;
		public LogOutCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptions<Tenant> options, IConfigurationRoot configuration, IHttpContextAccessor cta, IMediator mediator)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_configuration = configuration;
			contextAccessor = cta;
			_tenant = options.Value;
			_mediator = mediator;
		}
		public async Task<ResponseResult> Handle(LogOutCommand request, CancellationToken cancellationToken)
		{
			await _signInManager.SignOutAsync();
			await _mediator.Publish(new UserActivityEvent
			{
				ActivityObject = new UserActivity
				{
					UserId = GetCurrentUserId(),
					Timestamp = DateTime.UtcNow,
					ActivityType = "Login",
					IPAddress = this.contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString()

				}
			});

			return ResponseFactory.CreateSuccess("User logged out successfully!");
		}
		public long GetCurrentUserId()
		{
			// Accessing HttpContext directly in a controller: HttpContext.User
			// Using IHttpContextAccessor in a service: _httpContextAccessor.HttpContext.User
			var user = contextAccessor.HttpContext.User;
			// Find the NameIdentifier claim
			var userId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			return Convert.ToInt64(userId);
		}
	}

}
