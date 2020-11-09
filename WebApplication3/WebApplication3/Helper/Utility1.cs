using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;

namespace WebApplication3.Helper
{   
    public class Utility1
    {
        private CompleteModel db = new CompleteModel();

        private EntitiesRole role = new EntitiesRole();
        public Doctor getDoctorFromId(string id)
        {
            var doctor = db.Doctors.FirstOrDefault(m => m.Id == id);
            return doctor;
        }
        public Patients1 getPatientFromId(string id)
        {
            var patient = db.Patients1.FirstOrDefault(m => m.Id == id);
            return patient;
        }
    }
}