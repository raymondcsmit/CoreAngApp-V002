using Core.Queries;
using Core.Responses;

namespace ConfigureApp.Application.Queries
{

	public class GetApplicationQuery : IQuery<ResponseResult>
	{
		public long ApplicationId { get; set; }
	}
	public class GetAllApplicationQuery : IQuery<ResponseResult>
	{
	}
}
