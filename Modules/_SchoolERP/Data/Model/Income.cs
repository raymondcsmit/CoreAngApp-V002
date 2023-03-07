using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Income : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Income Head")] 
        public int? IncomeHeadId { get; set; }
        public virtual LedgerHead LedgerHead_IncomeHeadId { get; set; }
        [Required]
        [DisplayName("Payment Method")] 
        public int? PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod_PaymentMethodId { get; set; }
        [Required]
        [DisplayName("Amount")] 
        public Decimal Amount { get; set; }
        [Required]
        [DisplayName("Dated")] 
        public DateTime Dated { get; set; }
        [Required]
        [DisplayName("Running Year")] 
        public int? RunningYearId { get; set; }
        public virtual SessionYear SessionYear_RunningYearId { get; set; }
        [DisplayName("Note")] 
        public string Note { get; set; }

    }
}
