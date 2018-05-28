using TravelAgency.Models;
using TravelAgency.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Controllers
{
    public class PagedCustomerController : Login.BaseController
    {
        // GET: PagedCustomer
        public ActionResult Index(CustomerModel model)
        {
            int pageIndex = model.page ?? 1;

            TravelaEntities db = new TravelaEntities();

            model.Customers = (from cust in db.CustomerT.Where(f =>
                                    (String.IsNullOrEmpty(model.email) || f.email.Contains(model.email)) &&
                                    (String.IsNullOrEmpty(model.phone) || f.phone.Contains(model.phone))
                                    ).OrderByDescending(f => f.customerid)
                               select new CustomerListModel
                               {
                                   customername = cust.customername,
                                   customersurname = cust.customersurname,
                                   email = cust.email,
                                   phone = cust.phone


                               }).ToPagedList(pageIndex, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Customer", model);
            }
            else
            {
                return View(model);
            }


        }
    }
}