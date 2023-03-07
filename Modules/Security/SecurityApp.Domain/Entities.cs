using Core.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SecurityApp.Domain
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEnabled { get; set; }
        public string TenantId { get; set; }
        [IgnoreDataMember]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        //[JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }
    }
    public class ApplicationRole : IdentityRole<long>
    {
        public string SetupCode { get; set; }
        public ICollection<ApplicationRolePrivileges> ApplicationRolePrivileges { get; set; }
    }

    public class ApplicationRolePrivileges
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long PrivilegeId { get; set; }

        public ApplicationRole Role { get; set; }
        public Privileges Privilege { get; set; }
    }

    public class Privileges
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public ICollection<ApplicationRolePrivileges> ApplicationRolePrivileges { get; set; }
    }

   
}