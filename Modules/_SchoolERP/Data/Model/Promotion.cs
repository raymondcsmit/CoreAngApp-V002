using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Promotion : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Student")] 
        public int? StudentId { get; set; }
        public virtual Student Student_StudentId { get; set; }
        [Required]
        [DisplayName("Running Session")] 
        public int? RunningSessionId { get; set; }
        public virtual SessionYear SessionYear_RunningSessionId { get; set; }
        [Required]
        [DisplayName("Promote To Session")] 
        public int? PromoteToSessionId { get; set; }
        public virtual SessionYear SessionYear_PromoteToSessionId { get; set; }
        [Required]
        [DisplayName("Current Class")] 
        public int? CurrentClassId { get; set; }
        public virtual Classes Classes_CurrentClassId { get; set; }
        [Required]
        [DisplayName("Promote To Class")] 
        public int? PromoteToClassId { get; set; }
        public virtual Classes Classes_PromoteToClassId { get; set; }
        [Required]
        [DisplayName("Promote To Section")] 
        public int? PromoteToSectionId { get; set; }
        public virtual Section Section_PromoteToSectionId { get; set; }
        [Required]
        [DisplayName("Exam Mark")] 
        public int? ExamMarkId { get; set; }
        public virtual ExamMark ExamMark_ExamMarkId { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Next Roll Number")] 
        public string NextRollNumber { get; set; }
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
