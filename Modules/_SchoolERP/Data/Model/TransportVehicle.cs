using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class TransportVehicle : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Vehicle Number")] 
        public string VehicleNumber { get; set; }
        [StringLength(100)] 
        [DisplayName("Vehicle Model")] 
        public string VehicleModel { get; set; }
        [StringLength(100)] 
        [DisplayName("Driver")] 
        public string Driver { get; set; }
        [StringLength(100)] 
        [DisplayName("Vehicle License")] 
        public string VehicleLicense { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Vehicle Contact")] 
        public string VehicleContact { get; set; }
        [StringLength(200)] 
        [DisplayName("Note")] 
        public string Note { get; set; }

    }
}
