using Core.Responses;
using MediatR;

namespace SecurityApp.Application.Command
{
	public class LoginCommand : IRequest<ResponseResult>
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}
