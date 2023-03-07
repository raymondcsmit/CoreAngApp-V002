using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class MDay : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(20)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutine_DayIds { get; set; }

    }
}
