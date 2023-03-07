using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class CertificateType : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Certificate Name")] 
        public string CertificateName { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("School Name")] 
        public string SchoolName { get; set; }
        [Required]
        [StringLength(500)] 
        [DisplayName("Certificate Text")] 
        public string CertificateText { get; set; }
        [DisplayName("Footer Left Text")] 
        public string FooterLeftText { get; set; }
        [DisplayName("Footer Middle Text")] 
        public string FooterMiddleText { get; set; }
        [DisplayName("Footer Right Text")] 
        public string FooterRightText { get; set; }
        [DisplayName("Background")] 
        public string Background { get; set; }
        [DisplayName("Date Created")] 
        public Nullable<DateTime> DateCreated { get; set; }

    }
}
