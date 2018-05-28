using TravelAgency.Models;
using TravelAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Controllers
{
    public class CustomerPopupController : Login.BaseController
    {
        // GET: CustomerPopup
        public ActionResult Index()
        {
            CustomerPopupModel model = new CustomerPopupModel();
            return View(model);
        }

        public PartialViewResult CustomerList()
        {
            TravelaEntities db = new TravelaEntities();

            List<CustomerPopupModel> customerList = (from k in db.CustomerT
                                                     select new CustomerPopupModel
                                                     {
                                                         customerid = k.customerid,
                                                         customername = k.customername,
                                                         customersurname = k.customersurname,
                                                         birthdate = k.birthdate,
                                                         phone = k.phone,
                                                         email = k.email,
                                                         address = k.address
                                                     }).OrderByDescending(f => f.customerid).ToList();

            return PartialView(customerList);
        }

        [HttpPost]
        public string Create(CustomerPopupModel model)
        {
            try
            {
                TravelaEntities db = new TravelaEntities();
                CustomerT customer = null;
                if (model.customerid > 0)
                    customer = db.CustomerT.FirstOrDefault(f => f.customerid == model.customerid);
                else
                    customer = new CustomerT();

                customer.customername = model.customername;
                customer.customersurname = model.customersurname;
                customer.birthdate = model.birthdate;
                customer.phone = model.phone;
                customer.email = model.email;
                customer.address = model.address;

                if (model.customerid == 0)
                    db.CustomerT.Add(customer);

                return db.SaveChanges().ToString();
            }
            catch
            {
                return "-1";
            }
        }
        [HttpPost]
        public JsonResult Getir(int id)
        {
            TravelaEntities db = new TravelaEntities();
            CustomerT customer = db.CustomerT.FirstOrDefault(f => f.customerid == id);
            CustomerPopupModel model = new CustomerPopupModel();
            model.customerid = customer.customerid;
            model.customername = customer.customername;
            model.customersurname = customer.customersurname;
            model.birthdate = customer.birthdate;
            model.phone = customer.phone;
            model.email = customer.email;
            model.address = customer.address;
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}