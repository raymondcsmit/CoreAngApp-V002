using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Hostel : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Hostel Name")] 
        public string HostelName { get; set; }
        [Required]
        [DisplayName("Hostel Type")] 
        public int? HostelTypeId { get; set; }
        public virtual HostelType HostelType_HostelTypeId { get; set; }
        [Required]
        [DisplayName("Address")] 
        public string Address { get; set; }
        [StringLength(15)] 
        [DisplayName("Contact Number")] 
        public string ContactNumber { get; set; }
        [DisplayName("Note")] 
        public string Note { get; set; }
        public virtual ICollection<HostelRoom> HostelRoom_HostalIds { get; set; }

    }
}
