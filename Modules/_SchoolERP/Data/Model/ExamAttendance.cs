using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class ExamAttendance : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Student")] 
        public int? StudentId { get; set; }
        public virtual Student Student_StudentId { get; set; }
        [Required]
        [DisplayName("Exam Term")] 
        public int? ExamTermId { get; set; }
        public virtual ExamTerm ExamTerm_ExamTermId { get; set; }
        [Required]
        [DisplayName("Subject")] 
        public int? SubjectId { get; set; }
        public virtual Subject Subject_SubjectId { get; set; }
        [DisplayName("Is Present")] 
        public Nullable<bool> IsPresent { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modified")] 
        public Nullable<DateTime> DateModified { get; set; }

    }
}
