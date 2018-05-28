using TravelAgency.Models;
using TravelAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Controllers
{
    public class HomeController :Login.BaseController
    {
        public ActionResult Index(BookingModel model)
        {

            TravelaEntities db = new TravelaEntities();

            //toplam rezervation sayısı
            var rezercount = (from rezz in db.ReservationT select new { resevationnumber = rezz.reservationnumber }).Count();

            ViewBag.rezercount1 = rezercount;

            //onay bekleyenler
            var rezercountfalse = (from cus in db.CustomerT
                                   join rez in db.ReservationT on cus.customerid equals rez.customerid
                                   where rez.status == false

                                   select new BookingModel
                                   { customername = cus.customername }).Count();
            ViewBag.rezercountfalse2 = rezercountfalse;

            //hotellerin sayısı
            var hotelcount = (from hotel in db.HotelT select new { hotelname = hotel.hotelname }).Count();

            ViewBag.hotelcount = hotelcount;

            //londraya olan tour a isteklerin sayısı
            var tourcount1 = (from rezer in db.ReservationT

                              where rezer.tourid == 1
                              select new { tourid = rezer.tourid }).Count();

            ViewBag.tour1 = tourcount1;


            //oxforda olan tour a isteklerin sayısı
            var tourcount2 = (from rezer in db.ReservationT

                              where rezer.tourid == 3
                              select new { tourid = rezer.tourid }).Count();

            ViewBag.tour2 = tourcount2;


            return View();

        }
    }
}