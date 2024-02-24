using Core.Queries;
using Core.Responses;

namespace Providers.Application.Queries
{
	public class GetTokenQuery : IQuery<ResponseResult>
	{
		public string ProviderName { get; set; }
	}
}
