using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Setting : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Setting Key")] 
        public string SettingKey { get; set; }
        [Required]
        [StringLength(500)] 
        [DisplayName("Setting Value")] 
        public string SettingValue { get; set; }
        [StringLength(100)] 
        [DisplayName("Setting Group")] 
        public string SettingGroup { get; set; }

    }
}
