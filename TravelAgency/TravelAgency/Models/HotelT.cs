//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TravelAgency.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HotelT()
        {
            this.ReservationT = new HashSet<ReservationT>();
        }
    
        public int hotelid { get; set; }
        public string hotelname { get; set; }
        public string hotelcapacity { get; set; }
        public string hoteltype { get; set; }
        public string hotelprice { get; set; }
        public string hotelphone { get; set; }
        public string hoteladdress { get; set; }
        public Nullable<int> countryid { get; set; }
        public Nullable<int> tourid { get; set; }
    
        public virtual CountryT CountryT { get; set; }
        public virtual TourT TourT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationT> ReservationT { get; set; }
    }
}
