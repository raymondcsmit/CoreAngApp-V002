using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Gender : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        public virtual ICollection<User> User_GenderIds { get; set; }
        public virtual ICollection<Student> Student_GenderIds { get; set; }

    }
}
