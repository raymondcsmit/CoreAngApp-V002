using EmailApp.Application.Events;
using EmailApp.Domain;
using MailKit.Net.Smtp;
using MediatR;
using MimeKit;

namespace AuditLog.Application.Events.Handler
{
	public class SendEmailEventHandler : INotificationHandler<SendEmailEvent>
	{
		public async Task Handle(SendEmailEvent notification, CancellationToken cancellationToken)
		{
			await this.PerformAction(notification.EmailObject);
			// handle the event
			//return Task.CompletedTask;
		}
		private async Task PerformAction(EmailEntity obj)
		{
			var email = new MimeMessage();

			email.From.Add(new MailboxAddress("Waqar Habib", "waqarhabibmit@gmail.com"));
			email.To.Add(new MailboxAddress(obj.ToDisplayName, obj.ToEmail));

			email.Subject = obj.EmailSubject;
			email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
			{
				Text = obj.EmailBody
			};

			using (var smtp = new SmtpClient())
			{
				smtp.Connect("smtp.gmail.com", 587, false);
				smtp.Authenticate("waqarhabibmit@gmail.com", "spjftgfenzxdodia");

				smtp.Send(email);
				smtp.Disconnect(true);
			}

		}
	}
}
