using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    [Authorize]
    public class ConsultationsController : Controller
    {
        private CompleteModel db = new CompleteModel();
        private EntitiesRole role = new EntitiesRole();
        //private DBEntities db = new DBEntities();

        // GET: Consultations
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            ConsultationViewModel cvm = new ConsultationViewModel();
            cvm.userRole = role.AspNetUserRoles.FirstOrDefault(m => m.UserId == user).RoleId;
            if(cvm.userRole == "2")
            {
                cvm.consultation = db.Consultations.Where(m => m.DoctorId == user).ToList();
            }
            else
            {
                cvm.consultation = db.Consultations.Where(m => m.PatientId == user).ToList();
            }
            return View(cvm);
        }

        public ActionResult RatingIndex()
        {
            var user = User.Identity.GetUserId();

            RatingViewModel rvm = new RatingViewModel();
            rvm.review = db.Reviews.Where(m => m.PatientId == user).ToList();
            return View(rvm);
        }
        [HttpGet]
        public ActionResult AddRating(int id)
        {
            RatingViewModel model = new RatingViewModel();
            model.ratereview = db.Reviews.Find(id);
            model.docName = db.Doctors.Find(model.ratereview.DoctorId).Fullname;
            return View(model);
        }
        [HttpPost]
        public ActionResult AddRating(RatingViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model.ratereview).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Doctor Rated Successfully";
                return RedirectToAction("Index", "Patient");
            }
            return RedirectToAction("RatingIndex", "Consultations");
        }

        // GET: Consultations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConsultationViewModel cvm = new ConsultationViewModel();
            cvm.cons = db.Consultations.Find(id);
            if (cvm.cons == null)
            {
                return HttpNotFound();
            }
            return View(cvm);
        }

        // GET: Consultations/Create
        public ActionResult Create()
        {
            List<Doctor> doctors = db.Doctors.ToList();
            ViewBag.Doctors = (from item in db.Doctors.ToList()
                        select new SelectListItem
                            {
                                Text = item.Fullname,
                                Value = item.Id
                            });
            Consultation consultation = new Consultation();
            consultation.PatientId = User.Identity.GetUserId();
            return View(consultation);
        }

        // POST: Consultations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                db.Consultations.Add(consultation);
                
                //Review r = db.Reviews.FirstOrDefault(m=>m.)
                Review r = new Review();
                r.DoctorId=consultation.DoctorId;
                r.PatientId = consultation.PatientId;
                r.Rating = 0;
                Random rand = new Random();
                r.Id = rand.Next(1, 100000);
                db.Reviews.Add(r);
                db.SaveChanges();
                TempData["Message"] = "Consulation Booked Successfully";
                return RedirectToAction("Index");
            }

            return View(consultation);
        }

        // GET: Consultations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // POST: Consultations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultation);
        }

        // GET: Consultations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultation consultation = db.Consultations.Find(id);
            if (consultation == null)
            {
                return HttpNotFound();
            }
            return View(consultation);
        }

        // POST: Consultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultation consultation = db.Consultations.Find(id);
            db.Consultations.Remove(consultation);
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
