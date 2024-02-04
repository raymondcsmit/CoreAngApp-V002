using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRClient
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var connection = new HubConnectionBuilder()
				.WithUrl("wss://localhost:44381/signalr/notification-hub").WithAutomaticReconnect()
				.Build();

			connection.On<string, string>("ReceiveMessage", (user, message) =>
			{
				Console.WriteLine($"{user}: {message}");
			});


			await connection.StartAsync();
			await connection.InvokeAsync("SendMessage", "User1", "Hello, World!");

			Console.WriteLine("Connected to the hub");

			Console.ReadLine(); // Keep the app running
		}
	}
}
