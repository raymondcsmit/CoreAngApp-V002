using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Syllabus : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Class")] 
        public int? ClassId { get; set; }
        public virtual Classes Classes_ClassId { get; set; }
        [Required]
        [DisplayName("Subject")] 
        public int? SubjectId { get; set; }
        public virtual Subject Subject_SubjectId { get; set; }
        [DisplayName("Syllabus File")] 
        public string SyllabusFile { get; set; }
        [DisplayName("Extra Note")] 
        public string ExtraNote { get; set; }
        [Required]
        [DisplayName("Running Year")] 
        public int? RunningYearId { get; set; }
        public virtual SessionYear SessionYear_RunningYearId { get; set; }
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
