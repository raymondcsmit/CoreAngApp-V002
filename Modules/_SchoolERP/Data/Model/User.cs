using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class User : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("User Name")] 
        public string UserName { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Password")] 
        public string Password { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Full Name")] 
        public string FullName { get; set; }
        [Required]
        [DisplayName("Designation")] 
        public int? DesignationId { get; set; }
        public virtual Designation Designation_DesignationId { get; set; }
        [Required]
        [StringLength(15)] 
        [DisplayName("Phone")] 
        public string Phone { get; set; }
        [DisplayName("Address1")] 
        public string Address1 { get; set; }
        [DisplayName("Address2")] 
        public string Address2 { get; set; }
        [Required]
        [DisplayName("Gender")] 
        public int? GenderId { get; set; }
        public virtual Gender Gender_GenderId { get; set; }
        [StringLength(10)] 
        [DisplayName("Blood Group")] 
        public string BloodGroup { get; set; }
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
        [DisplayName("Date Of Birth")] 
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DisplayName("Date Of Joining")] 
        public DateTime DateOfJoining { get; set; }
        [DisplayName("Profile Picture")] 
        public string ProfilePicture { get; set; }
        [DisplayName("Resume")] 
        public string Resume { get; set; }
        [Required]
        [DisplayName("Salary Grade")] 
        public int? SalaryGradeId { get; set; }
        public virtual SalaryGrade SalaryGrade_SalaryGradeId { get; set; }
        [Required]
        [DisplayName("Salary Type")] 
        public int? SalaryTypeId { get; set; }
        public virtual SalaryType SalaryType_SalaryTypeId { get; set; }
        [StringLength(100)] 
        [DisplayName("Facebook")] 
        public string Facebook { get; set; }
        [StringLength(100)] 
        [DisplayName("Linkedin")] 
        public string Linkedin { get; set; }
        [StringLength(100)] 
        [DisplayName("Twitter")] 
        public string Twitter { get; set; }
        [StringLength(100)] 
        [DisplayName("Pinterest")] 
        public string Pinterest { get; set; }
        [StringLength(100)] 
        [DisplayName("Youtube")] 
        public string Youtube { get; set; }
        [StringLength(100)] 
        [DisplayName("Instagram")] 
        public string Instagram { get; set; }
        [StringLength(100)] 
        [DisplayName("Google Plus")] 
        public string GooglePlus { get; set; }
        [DisplayName("About Us")] 
        public string AboutUs { get; set; }
        [Required]
        [DisplayName("Can Login")] 
        public bool CanLogin { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }
        public virtual ICollection<RoleUser> RoleUser_UserIds { get; set; }
        public virtual ICollection<MenuPermission> MenuPermission_UserIds { get; set; }
        public virtual ICollection<Classes> Classes_TeacherIds { get; set; }
        public virtual ICollection<Section> Section_TeacherIds { get; set; }
        public virtual ICollection<Subject> Subject_TeacherIds { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutine_TeacherIds { get; set; }
        public virtual ICollection<UserAttendance> UserAttendance_UserIds { get; set; }
        public virtual ICollection<LibraryMember> LibraryMember_UserIds { get; set; }
        public virtual ICollection<TransportMember> TransportMember_UserIds { get; set; }
        public virtual ICollection<HostelMember> HostelMember_UserIds { get; set; }
        public virtual ICollection<MyDocument> MyDocument_UserIds { get; set; }

    }
}
