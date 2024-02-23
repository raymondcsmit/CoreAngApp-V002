using Core.Events;
using Core.Models;
using Core.Responses;
using Core.Utilities;
using EmailApp.Application.Events;
using EmailApp.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SecurityApp.Domain;
using SecurityApp.Infrastructure;

namespace SecurityApp.Application.Command.Handler
{
	public class RegisterTenantCommandHandler : IRequestHandler<RegisterTenantCommand, ResponseResult>
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly IMediator _mediator;

		public RegisterTenantCommandHandler(ApplicationDbContext dbContext, IMediator mediator)
		{
			_dbContext = dbContext;
			_mediator = mediator;
		}

		public async Task<ResponseResult> Handle(RegisterTenantCommand request, CancellationToken cancellationToken)
		{
			var tenantExists = await _dbContext.Tenants.Where(c => c.TenantEmail == request.TenantEmail).FirstOrDefaultAsync();

			if (tenantExists != null)
			{
				return ResponseFactory.CreateBadRequest("Tenant already registerd by this user!");
			}
			string uniqueCode = Helper.GenerateUniqueCode();
			TenantInfo tenant = new TenantInfo { TenantEmail = request.TenantEmail, TenantName = request.TenantName, TenantCode = uniqueCode };

			_dbContext.Tenants.Add(tenant);
			var result = await _dbContext.SaveChangesAsync();

			if ((await _dbContext.SaveChangesAsync()) != 1)
			{
				return ResponseFactory.CreateBadRequest("Tenant registration failed!");
			}

			string emailBody = CreateEmailBody(tenant, uniqueCode);
			await _mediator.Publish(new SendEmailEvent { EmailObject = new EmailEntity { ToEmail = tenant.TenantEmail, EmailSubject = "Tenant Code", ToDisplayName = tenant.TenantName, EmailBody = emailBody } });

			await PublishEvents(tenant, cancellationToken);
			return ResponseFactory.CreateSuccess("Tenant created successfully!", tenant);
		}

		private async Task PublishEvents(TenantInfo tenant, CancellationToken cancellationToken)
		{
			var auditLogEvent = new AuditLogEvent { AuditData = new AuditEntry { Action = "Register Tenant", EntityName = "TenantInfo", ObjectValue = SerializeDeSerialize.SerializeObject(tenant) } };
			await _mediator.Publish(auditLogEvent, cancellationToken);
		}

		private string CreateEmailBody(TenantInfo user, string code)
		{
			return $"<p>Please use the given code when register new user: <a href='http://localhost:4200/security/confirm?email={Uri.EscapeDataString(user.TenantEmail)}&code={code}'><h2>Click Here</h2></a>{code}</p>";
		}
	}
}
