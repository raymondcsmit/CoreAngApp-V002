using Core.Responses;
using MediatR;

namespace SecurityApp.Application.Command
{
	public class ConfirmCommand : IRequest<ResponseResult>
	{
		public string Email { get; set; }
		public string Code { get; set; }
	}
}
