using MediatR;
using SecurityApp.Domain;

namespace SecurityApp.Application.Events
{
	public class UserActivityEvent : INotification
	{
		public UserActivity ActivityObject { get; set; }
	}

}
