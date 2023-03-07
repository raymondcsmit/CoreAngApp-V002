using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AuditEntry : BaseEntity
    {
        public int AuditEntryId { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string Action { get; set; }
        public string ObjectValue { get; set; }
       
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
    public class SyncTable : BaseEntity
    {
        //public Int64 SyncTableId { get; set; }
        
        public string TablePKId { get; set; }
        public string JsonObject { get; set; }
        public string TableName { get; set; }
        public string FullTableName { get; set; }
        public string Assembly { get; set; }
        public bool IsSync { get; set; }
        public SyncMethod SyncMode { get; set; }

    }
    public enum SyncMethod
    {
        /// <summary>
        /// Data Pushed from Desktop to Server
        /// </summary>
        Push = 0,
        /// <summary>
        /// Data pull from Server to Desktop
        /// </summary>
        Pull = 1
    }
}
