using Core;
using Core.Events;
using Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolInfo.Module.Data
{

    public class SchoolInfoDbContext : DbContext
    {
        private readonly Tenant _tenant;
        private readonly IMediator _mediator;
        public SchoolInfoDbContext(CoreDbContextOptionsBuilder optionsBuilder, Tenant tenant, IMediator mediator)
       : base(optionsBuilder.SelectDatabase<SchoolInfoDbContext>())
        {
            _tenant = tenant;
            _mediator = mediator;
        }
        public virtual DbSet<SchoolInfoEntity> dbSetSchoolInfoEntities { get; set; }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            await _mediator.Publish(new AuditLogEvents { AuditDataList = GetChangesAuditEntry() });
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.Publish(new AuditLogEvents { AuditDataList = GetChangesAuditEntry() });
            return await base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {

            _mediator.Publish(new AuditLogEvents { AuditDataList = GetChangesAuditEntry() });
            //AuditEntries.AddRange(auditEntries);

            return base.SaveChanges();
        }
        private List<AuditEntry> GetChangesAuditEntry()
        {
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is not AuditEntry && (entry.State == EntityState.Added || entry.State == EntityState.Modified))
                {
                    auditEntries.Add(new AuditEntry
                    {
                        EntityName = entry.Entity.GetType().Name,
                        EntityId = (int)entry.CurrentValues["Id"],
                        Action = entry.State.ToString(),
                        ObjectValue = JsonSerializer.Serialize(entry),
                        Timestamp = DateTime.Now
                    });
                }
            }
            return auditEntries;
        }
        
    }
    }
