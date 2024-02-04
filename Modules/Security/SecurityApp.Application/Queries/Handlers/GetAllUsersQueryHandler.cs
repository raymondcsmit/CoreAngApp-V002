using Core.Queries;
using Core.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecurityApp.Domain;
using System.Net;

namespace SecurityApp.Application.Queries.Handler
{

	public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, ResponseResult>
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public GetAllUsersQueryHandler(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<ResponseResult> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
		{
			var users = await _userManager.Users.ToListAsync();

			if (users == null)
			{
				return new ResponseResult
				{
					Success = false,
					Message = "Users not found",
					StatusCode = HttpStatusCode.NotFound
				};
			}

			return new ResponseResult
			{
				Success = true,
				Data = users,
				TotalRecords = 1
			};
		}


	}
}
