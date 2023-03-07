using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Section : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Class")] 
        public int? ClassId { get; set; }
        public virtual Classes Classes_ClassId { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Section Name")] 
        public string SectionName { get; set; }
        [Required]
        [DisplayName("Teacher")] 
        public int? TeacherId { get; set; }
        public virtual User User_TeacherId { get; set; }
        [DisplayName("Note")] 
        public string Note { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutine_SectionIds { get; set; }
        public virtual ICollection<Student> Student_SectionIds { get; set; }
        public virtual ICollection<ExamMark> ExamMark_SectionIds { get; set; }
        public virtual ICollection<Promotion> Promotion_PromoteToSectionIds { get; set; }

    }
}
