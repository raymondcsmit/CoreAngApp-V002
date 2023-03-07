using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string TenantName{ get; set; }
        public string SyncMode { get; set; }
        public string AppMode { get; set; }
    }
    public class JwtConfiguration
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpiresInMinutes { get; set; }
        public int RefreshTokenExpiryInDays { get; set; }
    }
}
