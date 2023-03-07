using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SchoolERP.Data.Model;

namespace SchoolERP.Data.Models
{
    public class TransportRoute : BaseEntity
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Transport Route Title")] 
        public string TransportRouteTitle { get; set; }
        [Required]
        [StringLength(150)] 
        [DisplayName("Route Start")] 
        public string RouteStart { get; set; }
        [Required]
        [StringLength(150)] 
        [DisplayName("Route End")] 
        public string RouteEnd { get; set; }
        [DisplayName("Route Fare")] 
        public Nullable<Decimal> RouteFare { get; set; }
        [Required]
        [StringLength(500)] 
        [DisplayName("Assign Vehicle")] 
        public string AssignVehicle { get; set; }
        public virtual ICollection<TransportMember> TransportMember_TransportRouteIds { get; set; }

    }
}
