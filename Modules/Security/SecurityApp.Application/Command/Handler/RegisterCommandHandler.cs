﻿using Core.Events;
using Core.Models;
using Core.Responses;
using Core.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SecurityApp.Domain;
using System.Net;

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

			//if user exist return 500 error
			if (userExists != null)
				return new ResponseResult()
				{
					StatusCode = HttpStatusCode.BadRequest,
					Success = false,
					Message = "User already exists!"
				};

			//Todo Add default role to user
			//create user
			ApplicationUser user = new ApplicationUser()
			{
				Email = request.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = request.Email,
				IsEnabled = false,


			};
			var result = await _userManager.CreateAsync(user, request.Password);
			if (result.Succeeded)
			{
				var @event = new AuditLogEvent { AuditData = new AuditEntry() { Action = "Register User", EntityName = "ApplicationUser", ObjectValue = SerializeDeSerialize.SerializeObject(user) } };
				await _mediator.Publish(@event);
				var @syncEvent = new SyncLogEvent { Data = new SyncTable() { JsonObject = SerializeDeSerialize.SerializeObject(user), TableName = "ApplicationUser", TenantId = _tenant.TenantId, FullTableName = "ApplicationUser", TablePKId = user.Id.ToString() } };
				await _mediator.Publish(@syncEvent);
				string code = GeneratedCode();
				//var @emailEvent= new SendEmailEvent {EmailEntity= new EmailEntity() { } }
				SendEmail(user, code);
				//await _mediator.Publish(new UserCreatedEvent { UserName = user.UserName, Email = user.Email });
				return new ResponseResult()
				{

					Data = user,
					StatusCode = HttpStatusCode.OK,
					Success = true,
					Message = "User created successfully!"
				};
			}
			return new ResponseResult()
			{
				StatusCode = HttpStatusCode.BadRequest,
				Success = true,
				Message = "User creation failed! Please check user details and try again."
			};
			//return tokenHandler.WriteToken(token);
		}

		private string GeneratedCode()
		{
			Random generator = new Random();
			return generator.Next(0, 1000000).ToString("D6");
		}

		private void SendEmail(ApplicationUser user, string code)
		{

		}
	}

}
