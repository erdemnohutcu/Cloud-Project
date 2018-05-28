using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace TravelAgency.ViewModel
{
    public class CustomerModel
    {
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Phone")]
        public string phone { get; set; }

        public int? page { get; set; }

        public IPagedList<CustomerListModel> Customers { get; set; }
    }
}