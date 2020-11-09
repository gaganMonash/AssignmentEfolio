using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
   
    public class DoctorController : Controller
    {
        private CompleteModel db = new CompleteModel();
        private EntitiesRole role = new EntitiesRole();

        // GET: Doctor
        [Authorize(Roles = "Doctor")]
        public ActionResult Index()
        {
            var user = User.Identity.GetUserId();
            var userRole = role.AspNetUserRoles.FirstOrDefault(m => m.UserId == user).RoleId;
            if (userRole == "2")
            {
                ViewBag.UserName = db.Doctors.FirstOrDefault(m => m.Id == user).FirstName;
            }
            else
            {
                ViewBag.UserName = db.Patients1.FirstOrDefault(m => m.Id == user).FirstName;
            }
            return View();
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult SendEmail( )
        {
            EmailViewModel model = new EmailViewModel();
            ViewBag.Patients = (from item in db.Patients1.ToList()
                               select new SelectListItem
                               {
                                   Text = item.Fullname,
                                   Value = item.EmailId
                               });
            var user = User.Identity.GetUserId();
            model.emailFrom = "covidsafeprotect@gmail.com";

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult SendEmail(EmailViewModel model)
        {

            MailMessage mail = new MailMessage(model.emailFrom, model.emailTo);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            string password = "!QAZ2wsx00";
            NetworkCredential networkCredential = new NetworkCredential(model.emailFrom, password);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = networkCredential;
            smtp.Port = 587;
            smtp.Send(mail);
            ViewBag.Message = "Sent";
            return RedirectToAction("Index", "Doctor");
        }
        [Authorize(Roles = "Doctor")]
        public ActionResult SendEmailBulk()
        {
            EmailViewModel model = new EmailViewModel();
           // List<Patient>= db.Patients1.ToList();
            var user = User.Identity.GetUserId();
            List<String>patientIds= db.Consultations.Where(m => m.DoctorId == user).Select(m=>m.PatientId).Distinct().ToList();
            
            model.emailToAll = patientIds.Select(m => db.Patients1.FirstOrDefault(k => k.Id == m).EmailId).ToList();

            model.emailFrom = "covidsafeprotect@gmail.com";

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult SendEmailBulk(EmailViewModel model)
        {

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(model.emailFrom);
            foreach (var email in model.emailToAll) { 
                mail.To.Add(email);
            }
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            string password = "!QAZ2wsx00";
            NetworkCredential networkCredential = new NetworkCredential(model.emailFrom, password);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = networkCredential;
            smtp.Port = 587;
            smtp.Send(mail);
            TempData["Message"] = "Bulk Email Sent Successfully";
            return RedirectToAction("Index", "Doctor");
        }

    }

    

}