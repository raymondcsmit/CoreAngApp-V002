using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Subject : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Subject Name")] 
        public string SubjectName { get; set; }
        [StringLength(50)] 
        [DisplayName("Subject Code")] 
        public string SubjectCode { get; set; }
        [StringLength(100)] 
        [DisplayName("Author Name")] 
        public string AuthorName { get; set; }
        [Required]
        [DisplayName("Subject Type")] 
        public int? SubjectTypeId { get; set; }
        public virtual SubjectType SubjectType_SubjectTypeId { get; set; }
        [Required]
        [DisplayName("Class")] 
        public int? ClassId { get; set; }
        public virtual Classes Classes_ClassId { get; set; }
        [Required]
        [DisplayName("Teacher")] 
        public int? TeacherId { get; set; }
        public virtual User User_TeacherId { get; set; }
        [StringLength(50)] 
        [DisplayName("Pass Mark")] 
        public string PassMark { get; set; }
        [StringLength(50)] 
        [DisplayName("Full Mark")] 
        public string FullMark { get; set; }
        [DisplayName("Note")] 
        public string Note { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modified")] 
        public Nullable<DateTime> DateModified { get; set; }
        public virtual ICollection<Syllabus> Syllabus_SubjectIds { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutine_SubjectIds { get; set; }
        public virtual ICollection<Assignment> Assignment_SubjectIds { get; set; }
        public virtual ICollection<ExamSchedule> ExamSchedule_SubjectIds { get; set; }
        public virtual ICollection<ExamSuggestion> ExamSuggestion_SubjectIds { get; set; }
        public virtual ICollection<ExamAttendance> ExamAttendance_SubjectIds { get; set; }
        public virtual ICollection<ExamMark> ExamMark_SubjectIds { get; set; }

    }
}
