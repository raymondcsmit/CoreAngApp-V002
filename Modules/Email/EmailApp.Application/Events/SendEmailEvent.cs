using EmailApp.Domain;
using MediatR;

namespace EmailApp.Application.Events
{
	public class SendEmailEvent : INotification
	{
		public EmailEntity EmailObject { get; set; }
	}
}
