using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.ViewModel
{
    public class CustomerPopupModel
    {
       
        public int customerid { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "You should enter your name")]
        [StringLength(50, ErrorMessage = "Your limit is 50 character")]
        public string customername { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "You should enter your surname")]
        [StringLength(50, ErrorMessage = "Your limit is 50 character")]
        public string customersurname { get; set; }

        [Display(Name = "Birthdate")]
        [Required(ErrorMessage = "Birthdate is required. Field can't be empty")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime birthdate { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone is required. Field can't be empty")]
        public string phone { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required. Field can't be empty")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [Display(Name = "Address:")]
        [StringLength(100, ErrorMessage = "Your limit is 100 character")]
        [Required(ErrorMessage = "Address is required. Field can't be empty")]
        public string address { get; set; }
    }
}