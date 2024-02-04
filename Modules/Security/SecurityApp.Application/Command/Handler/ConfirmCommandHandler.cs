using Core.Events;
using Core.Models;
using Core.Responses;
using Core.Utilities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SecurityApp.Domain;

namespace SecurityApp.Application.Command.Handler
{

	public class ConfirmCommandHandler : IRequestHandler<ConfirmCommand, ResponseResult>
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IHttpContextAccessor contextAccessor;
		private readonly IConfigurationRoot _configuration;
		private readonly IMediator _mediator;
		private readonly Tenant _tenant;
		public ConfirmCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptions<Tenant> options, IConfigurationRoot configuration, IHttpContextAccessor cta, IMediator mediator)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_configuration = configuration;
			contextAccessor = cta;
			_tenant = options.Value;
			_mediator = mediator;
		}

		public async Task<ResponseResult> Handle(ConfirmCommand request, CancellationToken cancellationToken)
		{
			var user = await _signInManager.UserManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				return ResponseFactory.CreateNotFound("User not found.");
			}

			if (user.IsEnabled)
			{
				return ResponseFactory.CreateSuccess("User already confirmed successfully.");
			}

			var confirmResult = await _signInManager.UserManager.ConfirmEmailAsync(user, request.Code);
			if (!confirmResult.Succeeded)
			{
				return ResponseFactory.CreateBadRequest("Invalid confirmation code.");
			}

			//user.IsEnabled = true;
			//user.EmailConfirmed = true;
			var updateResult = await _signInManager.UserManager.UpdateAsync(user);
			if (!updateResult.Succeeded)
			{
				return ResponseFactory.CreateInternalServerError("Failed to update user.");
			}

			await PublishAuditLogEvent(user, cancellationToken);

			return ResponseFactory.CreateSuccess("User confirmed successfully.");
		}

		private async Task PublishAuditLogEvent(ApplicationUser user, CancellationToken cancellationToken)
		{
			var auditLogEvent = new AuditLogEvent
			{
				AuditData = new AuditEntry
				{
					Action = "User Confirm",
					EntityName = "ApplicationUser",
					ObjectValue = SerializeDeSerialize.SerializeObject(user)
				}
			};

			await _mediator.Publish(auditLogEvent, cancellationToken);
		}
	}

}
