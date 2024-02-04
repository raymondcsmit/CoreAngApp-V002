using Core.Events;
using Core.Models;
using Core.Responses;
using Core.Utilities;
using EmailApp.Application.Events;
using EmailApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SecurityApp.Domain;

namespace SecurityApp.Application.Command.Handler
{
	public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResponseResult>
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IMediator _mediator;
		private readonly Tenant _tenant;

		public RegisterCommandHandler(UserManager<ApplicationUser> userManager, IOptions<Tenant> options, IMediator mediator)
		{
			_userManager = userManager;
			_mediator = mediator;
			_tenant = options.Value;
		}

		public async Task<ResponseResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
		{
			var userExists = await _userManager.FindByNameAsync(request.Email);

			if (userExists != null)
			{
				return ResponseFactory.CreateBadRequest("User already exists!");
			}

			ApplicationUser user = new ApplicationUser
			{
				Email = request.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = request.Email,
				IsEnabled = false,
				TenantId = request.TenantId
			};

			var result = await _userManager.CreateAsync(user, request.Password);

			if (!result.Succeeded)
			{
				return ResponseFactory.CreateBadRequest("User creation failed! Please check user details and try again.");
			}

			string confirmationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
			// Assuming you handle the confirmation code storage elsewhere or in the email body itself

			await PublishEvents(user, cancellationToken);

			string emailBody = CreateEmailBody(user, confirmationCode);
			await _mediator.Publish(new SendEmailEvent { EmailObject = new EmailEntity { ToEmail = user.Email, EmailSubject = "Confirmation Code", ToDisplayName = user.FullName, EmailBody = emailBody } });

			return ResponseFactory.CreateSuccess("User created successfully!", user);
		}

		private async Task PublishEvents(ApplicationUser user, CancellationToken cancellationToken)
		{
			var auditLogEvent = new AuditLogEvent { AuditData = new AuditEntry { Action = "Register User", EntityName = "ApplicationUser", ObjectValue = SerializeDeSerialize.SerializeObject(user) } };
			await _mediator.Publish(auditLogEvent, cancellationToken);

			var syncEvent = new SyncLogEvent { Data = new SyncTable { JsonObject = SerializeDeSerialize.SerializeObject(user), TableName = "ApplicationUser", TenantId = _tenant.TenantId, FullTableName = "ApplicationUser", TablePKId = user.Id.ToString() } };
			await _mediator.Publish(syncEvent, cancellationToken);
		}

		private string CreateEmailBody(ApplicationUser user, string code)
		{
			return $"<p>Please use the given code to confirm your registration: <a href='http://localhost:4200/security/confirm?email={Uri.EscapeDataString(user.Email)}&code={code}'><h2>Click Here</h2></a></p>";
		}
	}
}
