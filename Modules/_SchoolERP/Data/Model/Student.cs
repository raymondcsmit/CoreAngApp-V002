using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Student : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Full Name")] 
        public string FullName { get; set; }
        [Required]
        [DisplayName("Guardian")] 
        public int? GuardianId { get; set; }
        public virtual Guardian Guardian_GuardianId { get; set; }
        [Required]
        [StringLength(15)] 
        [DisplayName("Phone Number")] 
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Date Of Birth")] 
        public DateTime DateOfBirth { get; set; }
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
        [Required]
        [DisplayName("Gender")] 
        public int? GenderId { get; set; }
        public virtual Gender Gender_GenderId { get; set; }
        [StringLength(20)] 
        [DisplayName("Blood Group")] 
        public string BloodGroup { get; set; }
        [Required]
        [DisplayName("Class")] 
        public int? ClassId { get; set; }
        public virtual Classes Classes_ClassId { get; set; }
        [Required]
        [DisplayName("Section")] 
        public int? SectionId { get; set; }
        public virtual Section Section_SectionId { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Roll Number")] 
        public string RollNumber { get; set; }
        [StringLength(100)] 
        [DisplayName("Registration No")] 
        public string RegistrationNo { get; set; }
        [DisplayName("Discount")] 
        public Nullable<Decimal> Discount { get; set; }
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
        public virtual ICollection<StudentAttendance> StudentAttendance_StudentIds { get; set; }
        public virtual ICollection<ExamAttendance> ExamAttendance_StudentIds { get; set; }
        public virtual ICollection<ExamMark> ExamMark_StudentIds { get; set; }
        public virtual ICollection<Promotion> Promotion_StudentIds { get; set; }
        public virtual ICollection<LibraryMember> LibraryMember_StudentIds { get; set; }
        public virtual ICollection<TransportMember> TransportMember_StudentIds { get; set; }
        public virtual ICollection<HostelMember> HostelMember_StudentIds { get; set; }
        public virtual ICollection<MyDocument> MyDocument_StudentIds { get; set; }
        public virtual ICollection<Invoice> Invoice_ToStudentIds { get; set; }

    }
}
