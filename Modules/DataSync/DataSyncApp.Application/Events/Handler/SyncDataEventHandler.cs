using Core.Events;
using Core.Models;
using DataSyncApp.Infrastructure;
using MediatR;

namespace DataSyncApp.Application.Events.Handler
{
	public class SyncDataEventHandler : INotificationHandler<SyncLogEvent>
	{
		private readonly DataSyncContext dbContext;
		public SyncDataEventHandler(DataSyncContext context)
		{
			this.dbContext = context;
		}
		public Task Handle(SyncLogEvent notification, CancellationToken cancellationToken)
		{
			this.PerformAction(notification.Data);
			// handle the event
			return Task.CompletedTask;
		}
		private void PerformAction(SyncTable obj)
		{
			dbContext.SyncTableEntries.Add(obj);
			dbContext.SaveChanges();
		}
	}
}
