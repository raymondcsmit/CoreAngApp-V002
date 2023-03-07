using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Visitor : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [Required]
        [StringLength(15)] 
        [DisplayName("Phone")] 
        public string Phone { get; set; }
        [Required]
        [StringLength(150)] 
        [DisplayName("Coming From")] 
        public string ComingFrom { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Meet To")] 
        public string MeetTo { get; set; }
        [Required]
        [DisplayName("Reason To Meet")] 
        public string ReasonToMeet { get; set; }
        [DisplayName("Remarks")] 
        public string Remarks { get; set; }
        [Required]
        [DisplayName("On Date")] 
        public DateTime OnDate { get; set; }
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
