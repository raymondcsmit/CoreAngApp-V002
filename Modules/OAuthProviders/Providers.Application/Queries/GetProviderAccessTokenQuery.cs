using Core.Queries;
using Core.Responses;

namespace Providers.Application.Queries
{
	public class GetProviderAccessTokenQuery : IQuery<ResponseResult>
	{
		public string ProviderName { get; set; }
		public string Code { get; set; }
		public string State { get; set; }
	}
}
