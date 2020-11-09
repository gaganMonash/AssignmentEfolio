using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    
    public class PatientController : Controller
    {
        private CompleteModel db = new CompleteModel();
        private EntitiesRole role = new EntitiesRole();
        // GET: Patient
        [Authorize(Roles = "Patient")]
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
        [Authorize(Roles = "Patient")]
        public ActionResult sendEmail()
        {
            return View();
        }

        [Authorize(Roles = "Patient")]
        public ActionResult showDoctor()
        {
            CompleteModel Cm = new CompleteModel();


            return View(Cm.Doctors.ToList());
        }
        [Authorize(Roles = "Patient")]
        public ActionResult showNearbuyDoctors()
        {
            //CompleteModel Cm = new CompleteModel();
            //List<Doctor>doctors=db.Doctors.ToList();
            List<Marker> markers = new List<Marker>();
            //ViewBag.Doctors
               markers = (from item in db.Doctors.ToList()
                               select new Marker
                               {
                                   latitude = (float)db.postcodes_geo.Find(item.SuburbId).latitude,
                                   longitude = (float)db.postcodes_geo.Find(item.SuburbId).longitude
                               }).ToList();
            return View(markers);
        }


        [Authorize(Roles = "Patient")]
        public ActionResult showGraph()
        {
            CompleteModel Cm = new CompleteModel();
            Dictionary<String, int> outputMap = new Dictionary<String, int>();
            List<Review>reviews=Cm.Reviews.ToList();

            Dictionary<String, List<int>> doctorMap = new Dictionary<String, List<int>>();
            foreach (var r in reviews)
            {
                if (doctorMap.ContainsKey(r.DoctorId))
                {
                    List<int> ratingsUser = doctorMap[r.DoctorId];
                    ratingsUser.Add(r.Rating);
                    doctorMap[r.DoctorId] = ratingsUser;
                }
                else {
                    List<int> ratingsUser = new List<int>();
                    ratingsUser.Add(r.Rating);
                    doctorMap[r.DoctorId] = ratingsUser;
                }
               

            }

            foreach (var each in doctorMap.Keys)
            {

                List<int> rates = doctorMap[each];
                var counter = 0;
                foreach (var e in rates)
                {
                    counter = counter + e;

                }

                var x = db.Doctors.Where(m => m.Id == each).Select(m => m.FirstName).FirstOrDefault();
                
                outputMap[x] = counter / rates.Count();
                


            }

            ViewBag.Stats = outputMap;
                return View();
        }

    }




}