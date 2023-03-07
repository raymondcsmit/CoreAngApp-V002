using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class PaymentMethod : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        public virtual ICollection<SalaryPayment> SalaryPayment_PaymentMethodIds { get; set; }
        public virtual ICollection<Income> Income_PaymentMethodIds { get; set; }
        public virtual ICollection<Expense> Expense_PaymentMethodIds { get; set; }
        public virtual ICollection<Invoice> Invoice_PaymentMethodIds { get; set; }

    }
}
