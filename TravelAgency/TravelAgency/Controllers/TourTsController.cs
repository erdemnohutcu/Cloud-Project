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
    public class TourTsController : Login.BaseController
    {
        private TravelaEntities db = new TravelaEntities();

        // GET: TourTs
        public ActionResult Index()
        {
            var tourT = db.TourT.Include(t => t.CountryT).Include(t => t.TourtypeT);
            return View(tourT.ToList());
        }

        // GET: TourTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourT tourT = db.TourT.Find(id);
            if (tourT == null)
            {
                return HttpNotFound();
            }
            return View(tourT);
        }

        // GET: TourTs/Create
        public ActionResult Create()
        {
            ViewBag.countryid = new SelectList(db.CountryT, "countryid", "countryname");
            ViewBag.tourtypeid = new SelectList(db.TourtypeT, "tourtypeid", "tourtypename");
            return View();
        }

        // POST: TourTs/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tourid,tourname,tourprice,tourcapacity,startdate,finishdate,tourtypeid,countryid")] TourT tourT)
        {
            if (ModelState.IsValid)
            {
                db.TourT.Add(tourT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.countryid = new SelectList(db.CountryT, "countryid", "countryname", tourT.countryid);
            ViewBag.tourtypeid = new SelectList(db.TourtypeT, "tourtypeid", "tourtypename", tourT.tourtypeid);
            return View(tourT);
        }

        // GET: TourTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourT tourT = db.TourT.Find(id);
            if (tourT == null)
            {
                return HttpNotFound();
            }
            ViewBag.countryid = new SelectList(db.CountryT, "countryid", "countryname", tourT.countryid);
            ViewBag.tourtypeid = new SelectList(db.TourtypeT, "tourtypeid", "tourtypename", tourT.tourtypeid);
            return View(tourT);
        }

        // POST: TourTs/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tourid,tourname,tourprice,tourcapacity,startdate,finishdate,tourtypeid,countryid")] TourT tourT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.countryid = new SelectList(db.CountryT, "countryid", "countryname", tourT.countryid);
            ViewBag.tourtypeid = new SelectList(db.TourtypeT, "tourtypeid", "tourtypename", tourT.tourtypeid);
            return View(tourT);
        }

        // GET: TourTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourT tourT = db.TourT.Find(id);
            if (tourT == null)
            {
                return HttpNotFound();
            }
            return View(tourT);
        }

        // POST: TourTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TourT tourT = db.TourT.Find(id);
            db.TourT.Remove(tourT);
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
