using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CEN511_Covid19.Models;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace CEN511_Covid19.Controllers
{
    public class SymptomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       private ApplicationUserManager _userManager;

        public SymptomsController()
        {
        }

        public SymptomsController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Symptoms
        public ActionResult Index()
        {

            string userID = User.Identity.GetUserId();
            List<Symptoms> symp = db.Symptoms.Where(x=>x.UserID == userID).ToList();
            int l = symp.Count - 1;
            if (l > 0) { 
                if (symp[l].SuggestedForTest == false)
                {
                    ViewBag.comment = "Your COVID Symptoms is provided to Doctor for Suggestions";
                }
                else if (symp[l].SuggestedForTest == true && symp[l].ResultStatus == false)
                {
                    ViewBag.comment = "Doctor suggested for testing. Please update your COVID-19 Test result";
                }

                else if (symp[l].SuggestedForTest == true && symp[l].ResultStatus == true)
                {
                    ViewBag.comment = "Doctor suggested for testing. Please take necessary precautions";
                }
            }
            return View(symp);
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
        public async Task<ActionResult> Create([Bind(Include = "SymptomsID,Fever,Cough,ShortnessOfBreathe,Aches,Headache,Ingigestion,StartingDayOfSymptoms")] Symptoms symptoms)
        {
            if (ModelState.IsValid)
            {
                string userID = User.Identity.GetUserId();
                var patientName = db.Users.Find(userID);
                symptoms.UserID = userID;
                symptoms.PatientName = patientName.FirstName + " " + patientName.LastName;
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
        public ActionResult Edit([Bind(Include = "SymptomsID,Fever,Cough,ShortnessOfBreathe,Aches,Headache,Ingigestion,StartingDayOfSymptoms, UserID,SuggestedForTest,ResultStatus,VerificationStatus,PatientName,RecoveryStatus")] Symptoms symptoms)
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

        public ActionResult UpdateStatus() 
        {
            string v = Request.Form["dropdown"];
            string i = Request.Form["item.SymptomsID"];

            if (!string.IsNullOrEmpty(v)) {
                Symptoms s = db.Symptoms.Find(Int32.Parse(i));
                if(v.Contains("1"))
                    s.SuggestedForTest = true;
                else
                    s.SuggestedForTest = false;

                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();
            }

            return View("../Account/Doctors");
        }

        public ActionResult Suspected() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult SuspectedList()
        {
            return View("SuspectedList");
        }
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult FeedbackList()
        {
            return View("FeedbackList");
        }
    }
}
