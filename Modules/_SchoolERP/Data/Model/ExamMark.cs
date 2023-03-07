using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class ExamMark : BaseEntity
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
        [DisplayName("Class")] 
        public int? ClassId { get; set; }
        public virtual Classes Classes_ClassId { get; set; }
        [Required]
        [DisplayName("Subject")] 
        public int? SubjectId { get; set; }
        public virtual Subject Subject_SubjectId { get; set; }
        [Required]
        [DisplayName("Section")] 
        public int? SectionId { get; set; }
        public virtual Section Section_SectionId { get; set; }
        [Required]
        [DisplayName("Mark")] 
        public Decimal Mark { get; set; }
        [Required]
        [DisplayName("Mark Obtain")] 
        public Decimal MarkObtain { get; set; }
        [Required]
        [DisplayName("Exam Grade")] 
        public int? ExamGradeId { get; set; }
        public virtual ExamGrade ExamGrade_ExamGradeId { get; set; }
        [StringLength(100)] 
        [DisplayName("Remark")] 
        public string Remark { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modified")] 
        public Nullable<DateTime> DateModified { get; set; }
        public virtual ICollection<Promotion> Promotion_ExamMarkIds { get; set; }

    }
}
