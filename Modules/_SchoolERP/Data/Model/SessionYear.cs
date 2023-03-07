using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class SessionYear : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [StringLength(100)] 
        [DisplayName("Details")] 
        public string Details { get; set; }
        [Required]
        [DisplayName("Is Running")] 
        public bool IsRunning { get; set; }
        public virtual ICollection<AppSetting> AppSetting_RunningYearIds { get; set; }
        public virtual ICollection<Syllabus> Syllabus_RunningYearIds { get; set; }
        public virtual ICollection<Assignment> Assignment_RunningYearIds { get; set; }
        public virtual ICollection<ExamTerm> ExamTerm_RunningYearIds { get; set; }
        public virtual ICollection<Promotion> Promotion_RunningSessionIds { get; set; }
        public virtual ICollection<Promotion> Promotion_PromoteToSessionIds { get; set; }
        public virtual ICollection<Income> Income_RunningYearIds { get; set; }

    }
}
