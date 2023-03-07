using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class LibraryIssueAndReturn : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Library Book")] 
        public int? LibraryBookId { get; set; }
        public virtual LibraryBook LibraryBook_LibraryBookId { get; set; }
        [Required]
        [DisplayName("Library Member")] 
        public int? LibraryMemberId { get; set; }
        public virtual LibraryMember LibraryMember_LibraryMemberId { get; set; }
        [Required]
        [DisplayName("Issue Date")] 
        public DateTime IssueDate { get; set; }
        [Required]
        [DisplayName("Due Date")] 
        public DateTime DueDate { get; set; }
        [DisplayName("Return Date")] 
        public Nullable<DateTime> ReturnDate { get; set; }
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
