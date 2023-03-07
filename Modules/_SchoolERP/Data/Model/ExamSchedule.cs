using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class ExamSchedule : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
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
        [DisplayName("Exam Date")] 
        public DateTime ExamDate { get; set; }
        [Required]
        [DisplayName("Start Time")] 
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayName("End Time")] 
        public DateTime EndTime { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Room Number")] 
        public string RoomNumber { get; set; }
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

    }
}
