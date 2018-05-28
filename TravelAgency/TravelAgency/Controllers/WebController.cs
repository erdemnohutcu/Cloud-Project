using TravelAgency.Models;
using TravelAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Controllers
{
    public class WebController : Controller
    {
        public static class RandomGen2
        {
            private static Random _global = new Random();
            [ThreadStatic]
            private static Random _local;

            public static int Next()
            {
                Random inst = _local;
                if (inst == null)
                {
                    int seed;
                    lock (_global) seed = _global.Next();
                    _local = inst = new Random(seed);
                }
                return inst.Next();
            }
        }
       
        public ActionResult Index()
        {
            BookingModel model = new BookingModel();
            TravelaEntities db = new TravelaEntities();

            List<TourT> tourList = db.TourT.OrderBy(f => f.tourname).ToList();

            model.TourTList = (from s in tourList
                               select new SelectListItem
                               {
                                   Text = s.tourname,
                                   Value = s.tourid.ToString()
                               }).ToList();

            model.TourTList.Insert(0, new SelectListItem { Value = "", Text = "Select", Selected = true });

            return View(model);

        }
        [HttpPost]
        public ActionResult Create(BookingModel model)
        {
            TravelaEntities db = new TravelaEntities();
            var customer = new CustomerT()
            {
                customerid = model.customerid,
                customername = model.customername,
                customersurname = model.customersurname,
                birthdate = model.birthdate,
                phone = model.phone,
                email = model.email,
                address = model.address
            };


            var reservation = new ReservationT()
            {
                customerid = model.customerid,
                hotelid = model.hotelid,
                tourid = model.tourid,
                status = model.status = false,
                reservationnumber = model.reservationnumber = RandomGen2.Next()

            };


            db.CustomerT.Add(customer);
            db.ReservationT.Add(reservation);

            db.SaveChanges();
            
            return Redirect("~/Web/Index");
        }

        [HttpPost]
        public JsonResult HotelList(int id)
        {
            TravelaEntities db = new TravelaEntities();
            List<HotelT> hotelList = db.HotelT.Where(f => f.tourid == id).OrderBy(f => f.hotelname).ToList();

            List<SelectListItem> itemList = (from i in hotelList
                                             select new SelectListItem
                                             {
                                                 Text = i.hotelname,
                                                 Value = i.hotelid.ToString(),

                                             }).ToList();

            return Json(itemList, JsonRequestBehavior.AllowGet);
        }
    }
}