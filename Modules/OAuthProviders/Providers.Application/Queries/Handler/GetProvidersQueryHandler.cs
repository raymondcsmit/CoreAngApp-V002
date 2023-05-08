using Core.Queries;
using Core.Responses;
using Microsoft.EntityFrameworkCore;
using Providers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Application.Queries.Handler
{
    
    public class GetProviderQueryHandler : IQueryHandler<GetProviderQuery, ResponseResult>
    {
        private readonly ProviderContext _dbContext;

        public GetProviderQueryHandler(ProviderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseResult> Handle(GetProviderQuery query, CancellationToken cancellationToken)
        {
            var provider = await _dbContext.ProviderSettingsEntries.Where(c=>c.Name==query.ProviderName).FirstOrDefaultAsync();

            if (provider == null)
            {
                return new ResponseResult
                {
                    Success = false,
                    Message = "Provider not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return new ResponseResult
            {
                Success = true,
                Data = provider,
                TotalRecords = 1
            };
        }
    }
}
