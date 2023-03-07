using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class Invoice : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("From School")] 
        public string FromSchool { get; set; }
        [Required]
        [DisplayName("To Student")] 
        public int? ToStudentId { get; set; }
        public virtual Student Student_ToStudentId { get; set; }
        [Required]
        [DisplayName("Dated")] 
        public DateTime Dated { get; set; }
        [DisplayName("Payment Method")] 
        public int? PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod_PaymentMethodId { get; set; }
        [DisplayName("Sub Total")] 
        public Nullable<Decimal> SubTotal { get; set; }
        [DisplayName("Discount")] 
        public Nullable<Decimal> Discount { get; set; }
        [StringLength(100)] 
        [DisplayName("Payment Status")] 
        public string PaymentStatus { get; set; }
        [DisplayName("Due Amount")] 
        public Nullable<Decimal> DueAmount { get; set; }
        [DisplayName("Total")] 
        public Nullable<Decimal> Total { get; set; }
        [StringLength(100)] 
        [DisplayName("Fees Head")] 
        public string FeesHead { get; set; }
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
