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
    
    public partial class TourT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourT()
        {
            this.HotelT = new HashSet<HotelT>();
            this.ReservationT = new HashSet<ReservationT>();
        }
    
        public int tourid { get; set; }
        public string tourname { get; set; }
        public string tourprice { get; set; }
        public string tourcapacity { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }
        public Nullable<System.DateTime> finishdate { get; set; }
        public Nullable<int> tourtypeid { get; set; }
        public Nullable<int> countryid { get; set; }
    
        public virtual CountryT CountryT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelT> HotelT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationT> ReservationT { get; set; }
        public virtual TourtypeT TourtypeT { get; set; }
    }
}