using Microsoft.AspNetCore.SignalR;

namespace NotificationApp
{
	public sealed class NotificationHub : Hub
	{
		public override async Task OnConnectedAsync()
		{
			await this.Clients.All.SendAsync("RecieveMessage", $"{Context.ConnectionId} has Joined");
		}
		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}
