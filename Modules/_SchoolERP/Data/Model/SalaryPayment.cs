using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class SalaryPayment : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Salary Grade")] 
        public int? SalaryGradeId { get; set; }
        public virtual SalaryGrade SalaryGrade_SalaryGradeId { get; set; }
        [Required]
        [DisplayName("Basic Salary")] 
        public Decimal BasicSalary { get; set; }
        [DisplayName("House Rent")] 
        public Nullable<Decimal> HouseRent { get; set; }
        [DisplayName("Transport Allowance")] 
        public Nullable<Decimal> TransportAllowance { get; set; }
        [DisplayName("Medical Allowance")] 
        public Nullable<Decimal> MedicalAllowance { get; set; }
        [DisplayName("Over Time Hourly Rate")] 
        public Nullable<Decimal> OverTimeHourlyRate { get; set; }
        [DisplayName("Provident Fund")] 
        public Nullable<Decimal> ProvidentFund { get; set; }
        [Required]
        [DisplayName("Hourly Rate")] 
        public Decimal HourlyRate { get; set; }
        [DisplayName("Total Allowance")] 
        public Nullable<Decimal> TotalAllowance { get; set; }
        [DisplayName("Total Deduction")] 
        public Nullable<Decimal> TotalDeduction { get; set; }
        [DisplayName("Gross Salary")] 
        public Nullable<Decimal> GrossSalary { get; set; }
        [DisplayName("Net Salary")] 
        public Nullable<Decimal> NetSalary { get; set; }
        [DisplayName("Over Time Total Hour")] 
        public Nullable<Decimal> OverTimeTotalHour { get; set; }
        [DisplayName("Bonus")] 
        public Nullable<Decimal> Bonus { get; set; }
        [DisplayName("Penalty")] 
        public Nullable<Decimal> Penalty { get; set; }
        [Required]
        [DisplayName("Which Month")] 
        public DateTime WhichMonth { get; set; }
        [Required]
        [DisplayName("Payment Method")] 
        public int? PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod_PaymentMethodId { get; set; }
        [Required]
        [DisplayName("Expense")] 
        public int? ExpenseId { get; set; }
        public virtual LedgerHead LedgerHead_ExpenseId { get; set; }
        [StringLength(100)] 
        [DisplayName("Note")] 
        public string Note { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modified")] 
        public Nullable<DateTime> DateModified { get; set; }

    }
}
