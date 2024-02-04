using MediatR;
using SecurityApp.Domain;
using SecurityApp.Infrastructure;

namespace SecurityApp.Application.Events.Handler
{
	public class UserActivityEventHandler : INotificationHandler<UserActivityEvent>
	{
		private readonly ApplicationDbContext dbContext;
		public UserActivityEventHandler(ApplicationDbContext appContext)
		{
			dbContext = appContext;
		}
		public async Task Handle(UserActivityEvent notification, CancellationToken cancellationToken)
		{
			await this.PerformAction(notification.ActivityObject);
		}
		private async Task PerformAction(UserActivity obj)
		{
			if (obj.Id == 0)
			{
				dbContext.UserActivities.Add(obj);
				await dbContext.SaveChangesAsync();
			}
		}
	}
}
