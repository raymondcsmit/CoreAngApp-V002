using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERP.Data.Model
{
    public class AuditEntry : BaseEntity
    {
        public int AuditEntryId { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string Action { get; set; }
        public string ObjectValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
