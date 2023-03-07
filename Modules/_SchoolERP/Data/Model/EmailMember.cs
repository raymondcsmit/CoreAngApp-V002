using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class EmailMember : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Email Message")] 
        public int? EmailMessageId { get; set; }
        public virtual EmailMessage EmailMessage_EmailMessageId { get; set; }
        [Required]
        [DisplayName("To User")] 
        public int ToUserId { get; set; }
        [DisplayName("Is Read")] 
        public Nullable<bool> IsRead { get; set; }
        [DisplayName("Date Updated")] 
        public Nullable<DateTime> DateUpdated { get; set; }

    }
}
