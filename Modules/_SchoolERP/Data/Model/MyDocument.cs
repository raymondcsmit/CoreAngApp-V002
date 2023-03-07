using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class MyDocument : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [DisplayName("Student")] 
        public int? StudentId { get; set; }
        public virtual Student Student_StudentId { get; set; }
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [DisplayName("File Name")] 
        public string FileName { get; set; }
        [StringLength(10)] 
        [DisplayName("File Extension")] 
        public string FileExtension { get; set; }
        [DisplayName("File Size")] 
        public Nullable<Decimal> FileSize { get; set; }
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
