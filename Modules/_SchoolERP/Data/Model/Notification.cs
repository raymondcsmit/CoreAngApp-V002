using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Notification : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [StringLength(100)] 
        [DisplayName("Table Name")] 
        public string TableName { get; set; }
        [DisplayName("Table")] 
        public Nullable<int> TableId { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Details")] 
        public string Details { get; set; }
        [StringLength(200)] 
        [DisplayName("Process To Url")] 
        public string ProcessToUrl { get; set; }
        [DisplayName("Is Read")] 
        public Nullable<bool> IsRead { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modified")] 
        public Nullable<DateTime> DateModified { get; set; }
        [DisplayName("To User")] 
        public Nullable<int> ToUserId { get; set; }
        [DisplayName("To Role")] 
        public Nullable<int> ToRoleId { get; set; }

    }
}
