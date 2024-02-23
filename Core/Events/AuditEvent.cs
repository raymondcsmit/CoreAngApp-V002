using Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Core.Events
{
	public class AuditLogEvent : INotification
	{
		public AuditEntry AuditData { get; set; }
	}
	public class AuditLogEvents : INotification
	{
		public List<AuditEntry> AuditDataList { get; set; }
	}

	public class SyncLogEvent : INotification
	{
		public SyncTable Data { get; set; }
	}
	public class NotificationEvent : INotification
	{
		public NotificationEntity Data { get; set; }
	}
}
