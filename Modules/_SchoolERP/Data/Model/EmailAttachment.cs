using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class EmailAttachment : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Email Message")] 
        public int? EmailMessageId { get; set; }
        public virtual EmailMessage EmailMessage_EmailMessageId { get; set; }
        [DisplayName("File Url")] 
        public string FileUrl { get; set; }
        [DisplayName("Is Deleted")] 
        public Nullable<bool> IsDeleted { get; set; }

    }
}
