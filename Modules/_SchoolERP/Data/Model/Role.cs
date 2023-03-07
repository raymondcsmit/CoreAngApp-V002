using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Role : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Role Name")] 
        public string RoleName { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }
        public virtual ICollection<RoleUser> RoleUser_RoleIds { get; set; }
        public virtual ICollection<MenuPermission> MenuPermission_RoleIds { get; set; }
        public virtual ICollection<User> User_RoleIds { get; set; }
        public virtual ICollection<Guardian> Guardian_RoleIds { get; set; }
        public virtual ICollection<Student> Student_RoleIds { get; set; }
        public virtual ICollection<Notice> Notice_NoticeForRoleIds { get; set; }
        public virtual ICollection<Event> Event_EventForRoleIds { get; set; }

    }
}
