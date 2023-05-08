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
    public class GetAllApplicationQueryHandler : IQueryHandler<GetAllApplicationQuery, ResponseResult>
    {
        private readonly ConfigureAppDbContext _dbContext;

        public GetAllApplicationQueryHandler(ConfigureAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    

        public async Task<ResponseResult> Handle(GetAllApplicationQuery request, CancellationToken cancellationToken)
        {
            var applications = await _dbContext.Applications
                                    .Include(a => a.Forms)
                                        .ThenInclude(f => f.Fields)
                                            .ThenInclude(field => field.Options)
                                    .Include(a => a.Forms)
                                        .ThenInclude(f => f.ActionApis)
                                    .Include(a => a.Forms)
                                        .ThenInclude(f => f.DisplayedColumns)
                                    .ToListAsync();

            //var applications = await _dbContext.Applications
            //    .Include(a => a.Forms)
            //        .ThenInclude(f => f.Fields)
            //            .ThenInclude(field => field.Options).ToListAsync();

            if (applications == null)
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
                Data = applications,
                TotalRecords = 1
            };
        }
    }

   

}
