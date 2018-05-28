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
    public class CustomerTsController : Login.BaseController
    {
        private TravelaEntities db = new TravelaEntities();

        // GET: CustomerTs
        public ActionResult Index()
        {
            return View(db.CustomerT.ToList());
        }

        // GET: CustomerTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerT customerT = db.CustomerT.Find(id);
            if (customerT == null)
            {
                return HttpNotFound();
            }
            return View(customerT);
        }

        // GET: CustomerTs/Create
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customerid,customername,customersurname,birthdate,phone,email,address")] CustomerT customerT)
        {
            if (ModelState.IsValid)
            {
                db.CustomerT.Add(customerT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerT);
        }

        // GET: CustomerTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerT customerT = db.CustomerT.Find(id);
            if (customerT == null)
            {
                return HttpNotFound();
            }
            return View(customerT);
        }

        // POST: CustomerTs/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customerid,customername,customersurname,birthdate,phone,email,address")] CustomerT customerT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerT);
        }

        // GET: CustomerTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerT customerT = db.CustomerT.Find(id);
            if (customerT == null)
            {
                return HttpNotFound();
            }
            return View(customerT);
        }

        // POST: CustomerTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerT customerT = db.CustomerT.Find(id);
            db.CustomerT.Remove(customerT);
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
