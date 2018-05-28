using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class HotelTsController : Login.BaseController
    {
        private TravelaEntities db = new TravelaEntities();

        // GET: HotelTs
        public ActionResult Index()
        {
            var hotelT = db.HotelT.Include(h => h.CountryT).Include(h => h.TourT);
            return View(hotelT.ToList());
        }

        // GET: HotelTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelT hotelT = db.HotelT.Find(id);
            if (hotelT == null)
            {
                return HttpNotFound();
            }
            return View(hotelT);
        }

        // GET: HotelTs/Create
        public ActionResult Create()
        {
            ViewBag.countryid = new SelectList(db.CountryT, "countryid", "countryname");
            ViewBag.tourid = new SelectList(db.TourT, "tourid", "tourname");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hotelid,hotelname,hotelcapacity,hoteltype,hotelprice,hotelphone,hoteladdress,countryid,tourid")] HotelT hotelT)
        {
            if (ModelState.IsValid)
            {
                db.HotelT.Add(hotelT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.countryid = new SelectList(db.CountryT, "countryid", "countryname", hotelT.countryid);
            ViewBag.tourid = new SelectList(db.TourT, "tourid", "tourname", hotelT.tourid);
            return View(hotelT);
        }

        // GET: HotelTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelT hotelT = db.HotelT.Find(id);
            if (hotelT == null)
            {
                return HttpNotFound();
            }
            ViewBag.countryid = new SelectList(db.CountryT, "countryid", "countryname", hotelT.countryid);
            ViewBag.tourid = new SelectList(db.TourT, "tourid", "tourname", hotelT.tourid);
            return View(hotelT);
        }

        // POST: HotelTs/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hotelid,hotelname,hotelcapacity,hoteltype,hotelprice,hotelphone,hoteladdress,countryid,tourid")] HotelT hotelT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.countryid = new SelectList(db.CountryT, "countryid", "countryname", hotelT.countryid);
            ViewBag.tourid = new SelectList(db.TourT, "tourid", "tourname", hotelT.tourid);
            return View(hotelT);
        }

        // GET: HotelTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelT hotelT = db.HotelT.Find(id);
            if (hotelT == null)
            {
                return HttpNotFound();
            }
            return View(hotelT);
        }

        // POST: HotelTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelT hotelT = db.HotelT.Find(id);
            db.HotelT.Remove(hotelT);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
