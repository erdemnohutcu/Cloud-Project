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
    
    public partial class CustomerT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustomerT()
        {
            this.ReservationT = new HashSet<ReservationT>();
        }
    
        public int customerid { get; set; }
        public string customername { get; set; }
        public string customersurname { get; set; }
        public System.DateTime birthdate { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservationT> ReservationT { get; set; }
    }
}