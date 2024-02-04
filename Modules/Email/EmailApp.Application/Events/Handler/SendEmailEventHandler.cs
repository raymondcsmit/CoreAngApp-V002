using EmailApp.Application.Events;
using EmailApp.Domain;
using MediatR;
using MimeKit;

namespace AuditLog.Application.Events.Handler
{
	public class SendEmailEventHandler : INotificationHandler<SendEmailEvent>
	{
		private readonly EmailConfiguration _emailConfig;

		public SendEmailEventHandler(EmailConfiguration emailConfig)
		{
			_emailConfig = emailConfig;
		}
		public async Task Handle(SendEmailEvent notification, CancellationToken cancellationToken)
		{
			await this.PerformActionAsync(notification.EmailObject);
			// handle the event
			//return Task.CompletedTask;
		}
		private async Task PerformActionAsync(EmailEntity obj)
		{
			var email = new MimeMessage();

			email.From.Add(MailboxAddress.Parse(_emailConfig.From));
			email.To.Add(MailboxAddress.Parse(obj.ToEmail));
			email.Subject = obj.EmailSubject;
			email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = obj.EmailBody };

			using (var smtp = new MailKit.Net.Smtp.SmtpClient())
			{
				await smtp.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, MailKit.Security.SecureSocketOptions.StartTls);
				await smtp.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

				await smtp.SendAsync(email);
				await smtp.DisconnectAsync(true);
			}
		}

	}
}
