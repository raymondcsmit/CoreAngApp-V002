using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Classes : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Class Name")] 
        public string ClassName { get; set; }
        [StringLength(100)] 
        [DisplayName("Alias Name")] 
        public string AliasName { get; set; }
        [Required]
        [DisplayName("Teacher")] 
        public int? TeacherId { get; set; }
        public virtual User User_TeacherId { get; set; }
        [Required]
        [DisplayName("Monthly Tution Fee")] 
        public Decimal MonthlyTutionFee { get; set; }
        [Required]
        [DisplayName("Admission Fee")] 
        public Decimal AdmissionFee { get; set; }
        [Required]
        [DisplayName("Exam Fee")] 
        public Decimal ExamFee { get; set; }
        [Required]
        [DisplayName("Certificate Fee")] 
        public Decimal CertificateFee { get; set; }
        [DisplayName("Note")] 
        public string Note { get; set; }
        public virtual ICollection<Section> Section_ClassIds { get; set; }
        public virtual ICollection<Subject> Subject_ClassIds { get; set; }
        public virtual ICollection<Syllabus> Syllabus_ClassIds { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutine_ClassIds { get; set; }
        public virtual ICollection<Student> Student_ClassIds { get; set; }
        public virtual ICollection<Assignment> Assignment_ClassIds { get; set; }
        public virtual ICollection<ExamSchedule> ExamSchedule_ClassIds { get; set; }
        public virtual ICollection<ExamSuggestion> ExamSuggestion_ClassIds { get; set; }
        public virtual ICollection<ExamMark> ExamMark_ClassIds { get; set; }
        public virtual ICollection<Promotion> Promotion_CurrentClassIds { get; set; }
        public virtual ICollection<Promotion> Promotion_PromoteToClassIds { get; set; }

    }
}
