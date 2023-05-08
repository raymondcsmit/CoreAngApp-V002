using System.ComponentModel.DataAnnotations;

namespace Providers.Domain
{
    public class OAuth2ProviderSettings : Core.Models.BaseEntity
    {
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string Scopes { get; set; }
        public string State { get; set; }//This is some key which will ensure the callback and other request
        public string RedirectUri { get; set; }
        public string UserinfoEndpoint { get; set; }
    }
    public class OAuthToken : Core.Models.BaseEntity
    {
        
        public string AccessToken { get; set; }
        public bool IsActive { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public DateTime IssuedAt { get; set; }
        public string State { get; set; }
        public string Provider { get; set; }
        public DateTime ExpireTime { get; set; }
        public long ProviderID { get; set; }
        public virtual OAuth2ProviderSettings ProviderSettings { get; set; }
    }

}