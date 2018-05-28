using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.ViewModel
{
    public class CustomerListModel
    {
        [Display(Name = "Name")]
        public string customername { get; set; }
        [Display(Name = "Surname")]
        public string customersurname { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Phone")]
        public string phone { get; set; }

    }
}