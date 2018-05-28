using TravelAgency.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.ViewModel
{
    public class BookingModel
    {
        
        public BookingModel()
        {
            this.HotelTList = new List<SelectListItem>();
            HotelTList.Add(new SelectListItem { Text = "Select", Value = "" });
        }
        [Key]
        public int customerid { get; set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage = "You should enter your name")]
        [StringLength(50, ErrorMessage = "Your limit is 50 character")]
        public string customername { get; set; }

        [Display(Name = "Surname:")]
        [Required(ErrorMessage = "You should enter your surname")]
        [StringLength(50, ErrorMessage = "Your limit is 50 character")]
        public string customersurname { get; set; }

        [Display(Name = "Birthdate:")]
        [Required(ErrorMessage = "Birthdate is required. Field can't be empty")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime birthdate { get; set; }

        [Display(Name = "Phone:")]
        [Required(ErrorMessage = "Phone is required. Field can't be empty")]
        public string phone { get; set; }

        [Display(Name = "Email address:")]
        [Required(ErrorMessage = "Email address is required. Field can't be empty")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [Display(Name = "Address:")]
        [StringLength(100, ErrorMessage = "Your limit is 100 character")]
        [Required(ErrorMessage = "Address is required. Field can't be empty")]
        public string address { get; set; }

        
        [Display(Name = "Select your Hotel:")]
        [Required(ErrorMessage = "Select Hotel is required. Field can't be empty")]
        public int hotelid { get; set; }


        public string hotelname { get; set; }


        [Display(Name = "Select your Tour:")]
        [Required(ErrorMessage = "Select Tour is required. Field can't be empty")]
        public int tourid { get; set; }


        public string tourname { get; set; }

        public int? reservationid;
        [Display(Name = "Reservation Number")]
        public int? reservationnumber;
        [Display(Name = "Status")]
        public bool? status;

        public List<SelectListItem> HotelTList { get; set; }
        public List<SelectListItem> TourTList { get; set; }
    }
}