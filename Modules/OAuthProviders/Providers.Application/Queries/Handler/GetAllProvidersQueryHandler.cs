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
    
    public class GetAllProvidersQueryHandler : IQueryHandler<GetAllProvidersQuery, ResponseResult>
    {
        private readonly ProviderContext _dbContext;

        public GetAllProvidersQueryHandler(ProviderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseResult> Handle(GetAllProvidersQuery query, CancellationToken cancellationToken)
        {
            var providers = await _dbContext.ProviderSettingsEntries.ToListAsync();

            if (providers == null)
            {
                return new ResponseResult
                {
                    Success = false,
                    Message = "Providers not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return new ResponseResult
            {
                Success = true,
                Data = providers,
                TotalRecords = 1
            };
        }

       
    }
}
