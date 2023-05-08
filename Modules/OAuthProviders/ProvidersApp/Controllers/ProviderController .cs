using Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Providers.Application.Queries;

namespace ProvidersApp.Controllers
{
    [ApiController]
    //[ModuleRoute("Security")]
    [Route("api/{module}/{controller}")]
    public class ProviderController : ControllerBase
    {
        //Todo: Get General Token, Same token be used for All the credentials behind obtaining the token will be one
        //: Get Specific Token, Each user will maintain his Own Token. Individual Credentials behind obtaining the token 

        private readonly IMediator mediatR;
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(ILogger<ProviderController> logger, IMediator mdr)
        {
            _logger = logger;
            mediatR = mdr;
        }
        [HttpGet(nameof(Callback))]
        public async Task<ResponseResult> Callback([FromBody] GetProviderAccessTokenQuery query)
        {
            return await mediatR.Send(query);
        }
        [HttpGet(nameof(ProviderURL))]
        public async Task<ResponseResult> ProviderURL([FromBody] GetProviderURLQuery query)
        {
            return await mediatR.Send(query);
        }
        [HttpGet(nameof(Token))]
        public async Task<ResponseResult> Token([FromBody] GetTokenQuery query)
        {
            return await mediatR.Send(query);
        }
    }

}