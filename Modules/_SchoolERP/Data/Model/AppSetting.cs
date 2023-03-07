using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class AppSetting: BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("School Name")] 
        public string SchoolName { get; set; }
        [Required]
        [DisplayName("Address")] 
        public string Address { get; set; }
        [Required]
        [StringLength(15)] 
        [DisplayName("Phone")] 
        public string Phone { get; set; }
        [StringLength(20)] 
        [DisplayName("Fax")] 
        public string Fax { get; set; }
        [Required]
[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]        [StringLength(50)] 
        [DisplayName("Email")] 

        public string Email { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Currency")] 
        public string Currency { get; set; }
        [Required]
        [StringLength(10)] 
        [DisplayName("Currency Symbol")] 
        public string CurrencySymbol { get; set; }
        [Required]
        [DisplayName("Language")] 
        public int? LanguageId { get; set; }
        public virtual Language Language_LanguageId { get; set; }
        [DisplayName("Logo")] 
        public string Logo { get; set; }
        [Required]
        [DisplayName("Running Year")] 
        public int? RunningYearId { get; set; }
        public virtual SessionYear SessionYear_RunningYearId { get; set; }
        [StringLength(50)] 
        [DisplayName("Location")] 
        public string Location { get; set; }
        [StringLength(100)] 
        [DisplayName("Facebook")] 
        public string Facebook { get; set; }
        [StringLength(100)] 
        [DisplayName("Twitter")] 
        public string Twitter { get; set; }
        [StringLength(100)] 
        [DisplayName("Linkedin")] 
        public string Linkedin { get; set; }
        [StringLength(100)] 
        [DisplayName("Google Plus")] 
        public string GooglePlus { get; set; }
        [StringLength(100)] 
        [DisplayName("Youtube")] 
        public string Youtube { get; set; }
        [StringLength(100)] 
        [DisplayName("Instagram")] 
        public string Instagram { get; set; }
        [StringLength(100)] 
        [DisplayName("Pinterest")] 
        public string Pinterest { get; set; }
        [Required]
        [DisplayName("Footer")] 
        public string Footer { get; set; }

    }
}
