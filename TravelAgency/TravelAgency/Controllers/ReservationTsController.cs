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
    public class ReservationTsController : Login.BaseController
    {
        private TravelaEntities db = new TravelaEntities();

        // GET: ReservationTs
        public ActionResult Index()
        {
            var reservationT = db.ReservationT.Include(r => r.CustomerT).Include(r => r.HotelT).Include(r => r.TourT);
            return View(reservationT.ToList());

        }

        // GET: ReservationTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationT reservationT = db.ReservationT.Find(id);
            if (reservationT == null)
            {
                return HttpNotFound();
            }
            return View(reservationT);
        }

        

        // GET: ReservationTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationT reservationT = db.ReservationT.Find(id);
            if (reservationT == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerid = new SelectList(db.CustomerT, "customerid", "customername", reservationT.customerid);
            ViewBag.hotelid = new SelectList(db.HotelT, "hotelid", "hotelname", reservationT.hotelid);
            ViewBag.tourid = new SelectList(db.TourT, "tourid", "tourname", reservationT.tourid);
            return View(reservationT);
        }

        // POST: ReservationTs/Edit/5
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reservationid,reservationnumber,customerid,tourid,status,hotelid")] ReservationT reservationT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerid = new SelectList(db.CustomerT, "customerid", "customername", reservationT.customerid);
            ViewBag.hotelid = new SelectList(db.HotelT, "hotelid", "hotelname", reservationT.hotelid);
            ViewBag.tourid = new SelectList(db.TourT, "tourid", "tourname", reservationT.tourid);
            return View(reservationT);
        }

        // GET: ReservationTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationT reservationT = db.ReservationT.Find(id);
            if (reservationT == null)
            {
                return HttpNotFound();
            }
            return View(reservationT);
        }

        // POST: ReservationTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationT reservationT = db.ReservationT.Find(id);
            db.ReservationT.Remove(reservationT);
            db.SaveChanges();
            return RedirectToAction("Index");
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
