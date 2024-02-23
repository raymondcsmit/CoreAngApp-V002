using Core.Queries;
using Core.Responses;
using Microsoft.EntityFrameworkCore;
using SecurityApp.Infrastructure;

namespace SecurityApp.Application.Queries.Handler
{

	public class GetAllTenantsQueryHandler : IQueryHandler<GetAllTenantsQuery, ResponseResult>
	{
		private readonly ApplicationDbContext _dbContext;

		public GetAllTenantsQueryHandler(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<ResponseResult> Handle(GetAllTenantsQuery query, CancellationToken cancellationToken)
		{
			var tenants = await _dbContext.Tenants.ToListAsync();

			if (tenants == null)
			{
				return ResponseFactory.CreateNotFound("Tenants not found!");
			}
			return ResponseFactory.CreateSuccess("Tenant created successfully!", tenants);
		}


	}
}
