using Microsoft.AspNetCore.SignalR;

namespace NotificationApp.Application.Service
{
	public class NotificationService : INotificationService
	{
		private readonly IHubContext<NotificationHub> _hubContext;

		public NotificationService(IHubContext<NotificationHub> hubContext)
		{
			_hubContext = hubContext;
		}
		public async Task SendMessage(string user, string message)
		{
			await _hubContext.Clients.All.SendAsync("ReceiveMessage", user, message);
		}
		public Task JoinGroup(string userId, string groupName)
		{
			return _hubContext.Groups.AddToGroupAsync(userId, groupName);
		}

		public Task LeaveGroup(string userId, string groupName)
		{
			return _hubContext.Groups.RemoveFromGroupAsync(userId, groupName);
		}
	}
}
