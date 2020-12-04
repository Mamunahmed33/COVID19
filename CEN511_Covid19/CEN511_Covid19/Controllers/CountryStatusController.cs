using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CEN511_Covid19.Models;

namespace CEN511_Covid19.Controllers
{
    public class CountryStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CountryStatus
        public ActionResult Index()
        {
            return View(db.CountryStatus.ToList());
        }

        // GET: CountryStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryStatus countryStatus = db.CountryStatus.Find(id);
            if (countryStatus == null)
            {
                return HttpNotFound();
            }
            return View(countryStatus);
        }

        // GET: CountryStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TotalSuspected,TotalAffected,Date")] CountryStatus countryStatus)
        {
            if (ModelState.IsValid)
            {
                db.CountryStatus.Add(countryStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryStatus);
        }

        // GET: CountryStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryStatus countryStatus = db.CountryStatus.Find(id);
            if (countryStatus == null)
            {
                return HttpNotFound();
            }
            return View(countryStatus);
        }

        // POST: CountryStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TotalSuspected,TotalAffected,Date")] CountryStatus countryStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryStatus);
        }

        // GET: CountryStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryStatus countryStatus = db.CountryStatus.Find(id);
            if (countryStatus == null)
            {
                return HttpNotFound();
            }
            return View(countryStatus);
        }

        // POST: CountryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryStatus countryStatus = db.CountryStatus.Find(id);
            db.CountryStatus.Remove(countryStatus);
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
