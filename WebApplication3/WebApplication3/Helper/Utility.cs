using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Helper
{
    public class Utility : Controller
    {
        // GET: Utility
        private CompleteModel db = new CompleteModel();
        private EntitiesRole role = new EntitiesRole();

        public Doctor getDoctorFromId(string id)
        {
            var doctor = db.Doctors.FirstOrDefault(m => m.Id == id);
            return doctor;
        }
        public Patient getPatientFromId(string id)
        {
            var patient = db.Patients.FirstOrDefault(m => m.Id == id);
            return patient;
        }
    }
}