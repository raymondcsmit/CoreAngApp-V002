using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Event : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Event Title")] 
        public string EventTitle { get; set; }
        [Required]
        [DisplayName("Event For Role")] 
        public int? EventForRoleId { get; set; }
        public virtual Role Role_EventForRoleId { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Event Place")] 
        public string EventPlace { get; set; }
        [Required]
        [DisplayName("From Date")] 
        public DateTime FromDate { get; set; }
        [Required]
        [DisplayName("To Date")] 
        public DateTime ToDate { get; set; }
        [DisplayName("Event Image")] 
        public string EventImage { get; set; }
        [Required]
        [DisplayName("Details")] 
        public string Details { get; set; }
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
