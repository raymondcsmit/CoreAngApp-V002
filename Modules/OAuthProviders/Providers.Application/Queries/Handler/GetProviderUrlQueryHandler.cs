using Core.Queries;
using Core.Responses;
using Microsoft.EntityFrameworkCore;
using Providers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Application.Queries.Handler
{
    
    public class GetProviderURLQueryHandler : IQueryHandler<GetProviderURLQuery, ResponseResult>
    {
        private readonly ProviderContext _dbContext;
        private readonly OAuth2ProviderFactory _oauth2ProviderFactory;
        public GetProviderURLQueryHandler(ProviderContext dbContext, OAuth2ProviderFactory oauth2ProviderFactory)
        {
            _dbContext = dbContext;
            _oauth2ProviderFactory = oauth2ProviderFactory;
        }

        public async Task<ResponseResult> Handle(GetProviderURLQuery query, CancellationToken cancellationToken )
        {
            var providerdata = await _dbContext.ProviderSettingsEntries.Where(c=>c.Name==query.ProviderName).FirstOrDefaultAsync();

            if (providerdata == null)
            {
                return new ResponseResult
                {
                    Success = false,
                    Message = "Provider not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            IOAuth2Provider provider = _oauth2ProviderFactory.CreateProvider(providerdata);

            return new ResponseResult
            {
                Success = true,
                Data = provider.GetAuthorizationUrlAsync(providerdata.Scopes,providerdata.RedirectUri),
                TotalRecords = 1
            };
        }
    }
}
