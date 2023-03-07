using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class EmailMessage : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("From User")] 
        public int FromUserId { get; set; }
        [StringLength(200)] 
        [DisplayName("Subject")] 
        public string Subject { get; set; }
        [DisplayName("Mail Text")] 
        public string MailText { get; set; }
        [DisplayName("Date Send")] 
        public Nullable<DateTime> DateSend { get; set; }
        [DisplayName("Is For Student")] 
        public Nullable<bool> IsForStudent { get; set; }
        [DisplayName("Is Approved")] 
        public Nullable<bool> IsApproved { get; set; }
        [DisplayName("Approved By")] 
        public Nullable<int> ApprovedBy { get; set; }
        [DisplayName("Approved Date")] 
        public Nullable<DateTime> ApprovedDate { get; set; }
        public virtual ICollection<EmailMember> EmailMember_EmailMessageIds { get; set; }
        public virtual ICollection<EmailAttachment> EmailAttachment_EmailMessageIds { get; set; }

    }
}
