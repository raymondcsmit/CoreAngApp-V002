using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class ExamTerm : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Exam Title")] 
        public string ExamTitle { get; set; }
        [Required]
        [DisplayName("Start Date")] 
        public DateTime StartDate { get; set; }
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
        [Required]
        [DisplayName("Running Year")] 
        public int? RunningYearId { get; set; }
        public virtual SessionYear SessionYear_RunningYearId { get; set; }
        public virtual ICollection<ExamSchedule> ExamSchedule_ExamTermIds { get; set; }
        public virtual ICollection<ExamSuggestion> ExamSuggestion_ExamTermIds { get; set; }
        public virtual ICollection<ExamAttendance> ExamAttendance_ExamTermIds { get; set; }
        public virtual ICollection<ExamMark> ExamMark_ExamTermIds { get; set; }

    }
}
