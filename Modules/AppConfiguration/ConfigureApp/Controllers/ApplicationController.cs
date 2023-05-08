using ConfigureApp.Application.Queries;
using Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ProvidersApp.Controllers
{
    [ApiController]
    //[ModuleRoute("Security")]
    [Route("api/{module}/{controller}")]
    public class ApplicationController : ControllerBase
    {
        private readonly IMediator mediatR;
        private readonly ILogger<ApplicationController> _logger;

        public ApplicationController(ILogger<ApplicationController> logger, IMediator mdr)
        {
            _logger = logger;
            mediatR = mdr;
        }
        //[HttpPost(nameof(Create))]
        //public async Task<ResponseResult> Create([FromBody] CreateProviderCommand command)
        //{
        //    return await mediatR.Send(command);
        //}
        [HttpGet(nameof(GetAll))]
        public async Task<ResponseResult> GetAll([FromBody] GetAllApplicationQuery query)
        {
            return await mediatR.Send(query);
        }
        [HttpGet(nameof(GetApplication))]
        public async Task<ResponseResult> GetApplication([FromBody] GetApplicationQuery query)
        {
            return await mediatR.Send(query);
        }
    }

}