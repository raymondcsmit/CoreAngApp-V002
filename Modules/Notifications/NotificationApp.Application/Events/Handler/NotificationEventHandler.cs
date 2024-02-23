
using Core.Events;
using Core.Models;
using MediatR;
using NotificationApp.Application.Service;

namespace NotificationApp.Application.Events.Handler
{
	public class NotificationEventHandler : INotificationHandler<NotificationEvent>
	{
		private readonly INotificationService _notificationService;

		public NotificationEventHandler(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		public async Task Handle(NotificationEvent notification, CancellationToken cancellationToken)
		{
			await this.PerformAction(notification.Data);
		}
		private async Task PerformAction(NotificationEntity obj)
		{
			switch (obj.MessageType)
			{
				case SignalRMessageType.SendMessage:
					{
						await _notificationService.SendMessage(obj.Sender, obj.Message);
					}
					break;
				case SignalRMessageType.RecievedMessage:
					{
						await _notificationService.SendMessage(obj.Sender, obj.Message);
					}
					break;
				case SignalRMessageType.LoginMessage:
					{
						await _notificationService.JoinGroup(obj.Sender, obj.Message);
					}
					break;
				case SignalRMessageType.LogOutMessage:
					{
						await _notificationService.LeaveGroup(obj.Sender, obj.Message);
					}
					break;
				default: break;

			}
			//use notification hub to inform user has joined
		}
	}
}
