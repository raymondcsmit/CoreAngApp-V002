using Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
