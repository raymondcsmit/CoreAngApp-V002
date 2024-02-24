using Core.Queries;
using Core.Responses;

namespace Providers.Application.Queries
{
	public class GetProviderURLQuery : IQuery<ResponseResult>
	{
		public string ProviderName { get; set; }
	}
}
