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
    public class HealthStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HealthStatus
        public ActionResult Index()
        {
            return View(db.HealthStatus.ToList());
        }

        // GET: HealthStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthStatus healthStatus = db.HealthStatus.Find(id);
            if (healthStatus == null)
            {
                return HttpNotFound();
            }
            return View(healthStatus);
        }

        // GET: HealthStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HealthStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HealthStatusID,SuggestedForTest,ResultStatus,VerificationStatus,RecoveryStatus")] HealthStatus healthStatus)
        {
            if (ModelState.IsValid)
            {
                db.HealthStatus.Add(healthStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(healthStatus);
        }

        // GET: HealthStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthStatus healthStatus = db.HealthStatus.Find(id);
            if (healthStatus == null)
            {
                return HttpNotFound();
            }
            return View(healthStatus);
        }

        // POST: HealthStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HealthStatusID,SuggestedForTest,ResultStatus,VerificationStatus,RecoveryStatus")] HealthStatus healthStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(healthStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(healthStatus);
        }

        // GET: HealthStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HealthStatus healthStatus = db.HealthStatus.Find(id);
            if (healthStatus == null)
            {
                return HttpNotFound();
            }
            return View(healthStatus);
        }

        // POST: HealthStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HealthStatus healthStatus = db.HealthStatus.Find(id);
            db.HealthStatus.Remove(healthStatus);
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
