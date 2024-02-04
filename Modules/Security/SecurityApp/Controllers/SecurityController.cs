﻿using Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityApp.Application.Command;
using SecurityApp.Application.Queries;
using SecurityApp.Domain;
using System.Threading.Tasks;

namespace SecurityApp.Controllers
{
	[ApiController]
	//[ModuleRoute("Security")]
	[Route("api/{module}/{controller}")]
	public class SecurityController : ControllerBase
	{
		private readonly IMediator mediatR;
		private readonly ILogger<SecurityController> _logger;

		public SecurityController(ILogger<SecurityController> logger, UserManager<ApplicationUser> um, IMediator mdr)
		{
			_logger = logger;
			mediatR = mdr;
		}
		//[HttpPost(nameof(SignIn))]
		//public async Task<Result> SignIn(RegisterRequest request)
		//{
		//    return await mediatR.Send(new RegisterUserCommand(request.UserName, request.Password));
		//}
		[HttpPost(nameof(LogIn))]
		public async Task<ResponseResult> LogIn([FromBody] LoginCommand command)
		{
			return await mediatR.Send(command);
		}
		[HttpPost(nameof(Register))]
		public async Task<ResponseResult> Register([FromBody] RegisterCommand command)
		{
			return await mediatR.Send(command);
		}
		[HttpPost(nameof(Confirm))]
		public async Task<ResponseResult> Confirm([FromBody] ConfirmCommand command)
		{
			return await mediatR.Send(command);
		}
		[HttpGet(nameof(Get))]
		public async Task<ResponseResult> Get()
		{
			var query = new GetAllUsersQuery();
			return await mediatR.Send(query);
		}
	}
}
