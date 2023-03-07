using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class FeesHead : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [Required]
        [DisplayName("Amount")] 
        public Decimal Amount { get; set; }
        [StringLength(100)] 
        [DisplayName("Note")] 
        public string Note { get; set; }

    }
}
