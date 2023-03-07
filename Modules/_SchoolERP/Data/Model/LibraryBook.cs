using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class LibraryBook : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Book Title")] 
        public string BookTitle { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Book")] 
        public string BookId { get; set; }
        [StringLength(100)] 
        [DisplayName("I S B N No")] 
        public string ISBNNo { get; set; }
        [StringLength(100)] 
        [DisplayName("Edition")] 
        public string Edition { get; set; }
        [StringLength(100)] 
        [DisplayName("Author")] 
        public string Author { get; set; }
        [StringLength(100)] 
        [DisplayName("Language")] 
        public string Language { get; set; }
        [StringLength(50)] 
        [DisplayName("Price")] 
        public string Price { get; set; }
        [Required]
        [DisplayName("Quantity")] 
        public int Quantity { get; set; }
        [StringLength(100)] 
        [DisplayName("Almira No")] 
        public string AlmiraNo { get; set; }
        [DisplayName("Cover Picture")] 
        public string CoverPicture { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modified")] 
        public Nullable<DateTime> DateModified { get; set; }
        public virtual ICollection<LibraryIssueAndReturn> LibraryIssueAndReturn_LibraryBookIds { get; set; }

    }
}
