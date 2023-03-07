using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class ExamGrade : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(20)] 
        [DisplayName("Grade Name")] 
        public string GradeName { get; set; }
        [Required]
        [DisplayName("Grade Point")] 
        public Decimal GradePoint { get; set; }
        [Required]
        [DisplayName("Mark From")] 
        public Decimal MarkFrom { get; set; }
        [Required]
        [DisplayName("Mark To")] 
        public Decimal MarkTo { get; set; }
        [DisplayName("Note")] 
        public string Note { get; set; }
        public virtual ICollection<ExamMark> ExamMark_ExamGradeIds { get; set; }

    }
}
