using ConfigureApp.Infrastructure;
using Core.Queries;
using Core.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureApp.Application.Queries.Handler
{
    public class GetApplicationQueryHandler : IQueryHandler<GetApplicationQuery, ResponseResult>
    {
        private readonly ConfigureAppDbContext _dbContext;

        public GetApplicationQueryHandler(ConfigureAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseResult> Handle(GetApplicationQuery query, CancellationToken cancellationToken)
        {
            var application = await _dbContext.Applications
                .Include(a => a.Forms)
                    .ThenInclude(f => f.Fields)
                        .ThenInclude(field => field.Options)
                .FirstOrDefaultAsync(a => a.Id == query.ApplicationId);

            if (application == null)
            {
                return new ResponseResult
                {
                    Success = false,
                    Message = "Application not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return new ResponseResult
            {
                Success = true,
                Data = application,
                TotalRecords = 1
            };
        }
    }

   

}
