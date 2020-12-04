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
    public class SymptomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Symptoms
        public ActionResult Index()
        {
            return View(db.Symptoms.ToList());
        }

        // GET: Symptoms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptoms symptoms = db.Symptoms.Find(id);
            if (symptoms == null)
            {
                return HttpNotFound();
            }
            return View(symptoms);
        }

        // GET: Symptoms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Symptoms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SymptomsID,Fever,Cough,ShortnessOfBreathe,Aches,Headache,Ingigestion,StartingDayOfSymptoms")] Symptoms symptoms)
        {
            if (ModelState.IsValid)
            {
                db.Symptoms.Add(symptoms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(symptoms);
        }

        // GET: Symptoms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptoms symptoms = db.Symptoms.Find(id);
            if (symptoms == null)
            {
                return HttpNotFound();
            }
            return View(symptoms);
        }

        // POST: Symptoms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SymptomsID,Fever,Cough,ShortnessOfBreathe,Aches,Headache,Ingigestion,StartingDayOfSymptoms")] Symptoms symptoms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symptoms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(symptoms);
        }

        // GET: Symptoms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Symptoms symptoms = db.Symptoms.Find(id);
            if (symptoms == null)
            {
                return HttpNotFound();
            }
            return View(symptoms);
        }

        // POST: Symptoms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Symptoms symptoms = db.Symptoms.Find(id);
            db.Symptoms.Remove(symptoms);
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
