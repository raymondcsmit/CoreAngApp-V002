using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class ClassRoutine : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Class")] 
        public int? ClassId { get; set; }
        public virtual Classes Classes_ClassId { get; set; }
        [Required]
        [DisplayName("Section")] 
        public int? SectionId { get; set; }
        public virtual Section Section_SectionId { get; set; }
        [Required]
        [DisplayName("Subject")] 
        public int? SubjectId { get; set; }
        public virtual Subject Subject_SubjectId { get; set; }
        [Required]
        [DisplayName("Teacher")] 
        public int? TeacherId { get; set; }
        public virtual User User_TeacherId { get; set; }
        [Required]
        [DisplayName("Day")] 
        public int? DayId { get; set; }
        public virtual MDay MDay_DayId { get; set; }
        [Required]
        [DisplayName("Start Time")] 
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayName("End Time")] 
        public DateTime EndTime { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Room Number")] 
        public string RoomNumber { get; set; }
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
