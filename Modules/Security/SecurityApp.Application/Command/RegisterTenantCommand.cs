using Core.Responses;
using MediatR;

namespace SecurityApp.Application.Command
{
	public class RegisterTenantCommand : IRequest<ResponseResult>
	{
		public string TenantName { get; set; }
		public string TenantEmail { get; set; }
	}
}
