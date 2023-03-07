using Core;
using Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityApp.Application.Command;
using SecurityApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, world!");
        }
    }
}
