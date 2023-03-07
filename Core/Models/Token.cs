using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TokenDetail
    {
        public string AccessToken { get; set; }
        public int TokenLifeTime { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ExpireTime { get; set; }
        public override string ToString()
        {
            var serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            return serializedObject;
        }

    }
    public class RefreshToken
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string Token { get; set; }
        public DateTime Expiry { get; set; }
        public bool IsExpired
        {
            get { return DateTime.UtcNow >= Expiry; }
        }
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public string UserId { get; set; }
        public bool IsActive
        {
            get { return Revoked == null && !IsExpired; }
        }
    }
}
