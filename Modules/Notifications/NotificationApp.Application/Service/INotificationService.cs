namespace NotificationApp.Application.Service
{
	public interface INotificationService
	{
		public Task SendMessage(string user, string message);
		public Task JoinGroup(string userId, string groupName);

		public Task LeaveGroup(string userId, string groupName);
	}

}
