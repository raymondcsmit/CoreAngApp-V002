using Core.Queries;
using Core.Responses;

namespace Providers.Application.Queries
{
	public class GetProviderQuery : IQuery<ResponseResult>
	{
		public string ProviderName { get; set; }
	}
}
