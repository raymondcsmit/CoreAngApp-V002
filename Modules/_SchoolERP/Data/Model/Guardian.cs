using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Guardian : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Full Name")] 
        public string FullName { get; set; }
        [Required]
        [DisplayName("Guardian Relation")] 
        public int? GuardianRelationId { get; set; }
        public virtual GuardianRelation GuardianRelation_GuardianRelationId { get; set; }
        [Required]
        [StringLength(15)] 
        [DisplayName("Phone Number")] 
        public string PhoneNumber { get; set; }
        [StringLength(100)] 
        [DisplayName("Profession")] 
        public string Profession { get; set; }
        [DisplayName("Address1")] 
        public string Address1 { get; set; }
        [DisplayName("Address2")] 
        public string Address2 { get; set; }
        [StringLength(100)] 
        [DisplayName("Religion")] 
        public string Religion { get; set; }
        [Required]
        [DisplayName("Role")] 
        public int? RoleId { get; set; }
        public virtual Role Role_RoleId { get; set; }
        [Required]
[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]        [StringLength(50)] 
        [DisplayName("Email")] 

        public string Email { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Password")] 
        public string Password { get; set; }
        [DisplayName("Profile Picture")] 
        public string ProfilePicture { get; set; }
        [DisplayName("About")] 
        public string About { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modified")] 
        public Nullable<DateTime> DateModified { get; set; }
        public virtual ICollection<Student> Student_GuardianIds { get; set; }

    }
}
