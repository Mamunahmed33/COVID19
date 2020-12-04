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
    public class SuspectedsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Suspecteds
        public ActionResult Index()
        {
            return View(db.Suspecteds.ToList());
        }

        // GET: Suspecteds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspected suspected = db.Suspecteds.Find(id);
            if (suspected == null)
            {
                return HttpNotFound();
            }
            return View(suspected);
        }

        // GET: Suspecteds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suspecteds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PhoneNumber")] Suspected suspected)
        {
            if (ModelState.IsValid)
            {
                db.Suspecteds.Add(suspected);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suspected);
        }

        // GET: Suspecteds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspected suspected = db.Suspecteds.Find(id);
            if (suspected == null)
            {
                return HttpNotFound();
            }
            return View(suspected);
        }

        // POST: Suspecteds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PhoneNumber")] Suspected suspected)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suspected).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suspected);
        }

        // GET: Suspecteds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suspected suspected = db.Suspecteds.Find(id);
            if (suspected == null)
            {
                return HttpNotFound();
            }
            return View(suspected);
        }

        // POST: Suspecteds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suspected suspected = db.Suspecteds.Find(id);
            db.Suspecteds.Remove(suspected);
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
