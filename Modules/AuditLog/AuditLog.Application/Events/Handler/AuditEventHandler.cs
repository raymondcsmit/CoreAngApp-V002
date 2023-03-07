using AuditLog.Infrastructure;
using Core.Events;
using Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditLog.Application.Events.Handler
{
    public class AuditLogEventHandler : INotificationHandler<AuditLogEvent>
    {
        private readonly AuditLogContext dbContext;
        public AuditLogEventHandler(AuditLogContext context)
        {
            this.dbContext = context;
        }
        public async Task Handle(AuditLogEvent notification, CancellationToken cancellationToken)
        {
            await this.PerformAction(notification.AuditData);
            // handle the event
            //return Task.CompletedTask;
        }
        private async Task PerformAction(AuditEntry obj)
        {
            if (obj.Id == 0)
            {
                dbContext.AuditEntries.Add(obj);
                await dbContext.SaveChangesAsync();//.SaveChanges();
            }
        }
    }

    public class AuditLogEventHandlerList : INotificationHandler<AuditLogEvents>
    {
        private readonly AuditLogContext dbContext;
        public AuditLogEventHandlerList(AuditLogContext context)
        {
            this.dbContext = context;
        }
        public Task Handle(AuditLogEvents notification, CancellationToken cancellationToken)
        {
            this.PerformAction(notification.AuditDataList);
            // handle the event
            return Task.CompletedTask;
        }
        private void PerformAction(List<AuditEntry> data)
        {
            dbContext.AuditEntries.AddRange(data);
            dbContext.SaveChanges();
        }
    }


}
