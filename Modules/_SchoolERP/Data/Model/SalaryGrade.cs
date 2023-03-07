using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class SalaryGrade : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
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
        [StringLength(100)] 
        [DisplayName("Short Note")] 
        public string ShortNote { get; set; }
        public virtual ICollection<User> User_SalaryGradeIds { get; set; }
        public virtual ICollection<SalaryPayment> SalaryPayment_SalaryGradeIds { get; set; }

    }
}
