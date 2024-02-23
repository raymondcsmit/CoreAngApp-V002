using Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityApp.Application.Command;
using SecurityApp.Application.Queries;
using System.Threading.Tasks;

namespace SecurityApp.Controllers
{
	[ApiController]
	//[ModuleRoute("Security")]
	[Route("api/{module}/{controller}")]
	public class TenantController : ControllerBase
	{
		private readonly IMediator mediatR;
		private readonly ILogger<SecurityController> _logger;

		public TenantController(ILogger<SecurityController> logger, IMediator mdr)
		{
			_logger = logger;
			mediatR = mdr;
		}

		[HttpPost(nameof(Register))]
		public async Task<ResponseResult> Register([FromBody] RegisterTenantCommand command)
		{
			return await mediatR.Send(command);
		}
		[HttpGet(nameof(Get))]
		public async Task<ResponseResult> Get()
		{
			var query = new GetAllTenantsQuery();
			return await mediatR.Send(query);
		}
	}
}
