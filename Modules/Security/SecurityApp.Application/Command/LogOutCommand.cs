using Core.Responses;
using MediatR;

namespace SecurityApp.Application.Command
{
	public class LogOutCommand : IRequest<ResponseResult>
	{
	}
}
