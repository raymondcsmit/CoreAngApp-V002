using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class LedgerHead : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Head")] 
        public string Head { get; set; }
        [DisplayName("Note")] 
        public string Note { get; set; }
        [DisplayName("Parent")] 
        public Nullable<int> ParentId { get; set; }
        public virtual LedgerHead LedgerHead2 { get; set; }
        public virtual ICollection<SalaryPayment> SalaryPayment_ExpenseIds { get; set; }
        public virtual ICollection<LedgerHead> LedgerHead_ParentIds { get; set; }
        public virtual ICollection<Income> Income_IncomeHeadIds { get; set; }
        public virtual ICollection<Expense> Expense_ExpenseHeadIds { get; set; }

    }
}
