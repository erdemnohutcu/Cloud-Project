﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TravelaEntities : DbContext
    {
        public TravelaEntities()
            : base("name=TravelaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CountryT> CountryT { get; set; }
        public virtual DbSet<CustomerT> CustomerT { get; set; }
        public virtual DbSet<HotelT> HotelT { get; set; }
        public virtual DbSet<ReservationT> ReservationT { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TourT> TourT { get; set; }
        public virtual DbSet<TourtypeT> TourtypeT { get; set; }
        public virtual DbSet<UserT> UserT { get; set; }
    }
}
