using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class HostelRoom : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Hostal")] 
        public int? HostalId { get; set; }
        public virtual Hostel Hostel_HostalId { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Room No")] 
        public string RoomNo { get; set; }
        [Required]
        [DisplayName("Is A C")] 
        public bool IsAC { get; set; }
        [Required]
        [DisplayName("Total Seat")] 
        public int TotalSeat { get; set; }
        [Required]
        [DisplayName("Price Per Seat")] 
        public Decimal PricePerSeat { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modified")] 
        public Nullable<DateTime> DateModified { get; set; }
        public virtual ICollection<HostelMember> HostelMember_HostelRoomIds { get; set; }

    }
}
