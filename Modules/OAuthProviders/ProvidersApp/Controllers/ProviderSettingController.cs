using Core.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Providers.Application.Queries;
using SecurityApp.Application.Command;

namespace ProvidersApp.Controllers
{
    [ApiController]
    //[ModuleRoute("Security")]
    [Route("api/{module}/{controller}")]
    public class ProviderSetting : ControllerBase
    {
        private readonly IMediator mediatR;
        private readonly ILogger<ProviderSetting> _logger;

        public ProviderSetting(ILogger<ProviderSetting> logger, IMediator mdr)
        {
            _logger = logger;
            mediatR = mdr;
        }
        [HttpPost(nameof(Create))]
        public async Task<ResponseResult> Create([FromBody] CreateProviderCommand command)
        {
            return await mediatR.Send(command);
        }

        [HttpGet(nameof(GetAllProviders))]
        public async Task<ResponseResult> GetAllProviders([FromBody] GetAllProvidersQuery query)
        {
            return await mediatR.Send(query);
        }
    }

}