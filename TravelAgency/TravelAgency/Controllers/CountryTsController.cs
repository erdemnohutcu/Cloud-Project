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
    public class CountryTsController : Login.BaseController
    {
        private TravelaEntities db = new TravelaEntities();

        // GET: CountryTs
        public ActionResult Index()
        {
            return View(db.CountryT.ToList());
        }

        // GET: CountryTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryT countryT = db.CountryT.Find(id);
            if (countryT == null)
            {
                return HttpNotFound();
            }
            return View(countryT);
        }

        // GET: CountryTs/Create
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "countryid,countryname")] CountryT countryT)
        {
            if (ModelState.IsValid)
            {
                db.CountryT.Add(countryT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryT);
        }

        // GET: CountryTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryT countryT = db.CountryT.Find(id);
            if (countryT == null)
            {
                return HttpNotFound();
            }
            return View(countryT);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "countryid,countryname")] CountryT countryT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryT);
        }

        // GET: CountryTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryT countryT = db.CountryT.Find(id);
            if (countryT == null)
            {
                return HttpNotFound();
            }
            return View(countryT);
        }

        // POST: CountryTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryT countryT = db.CountryT.Find(id);
            db.CountryT.Remove(countryT);
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
