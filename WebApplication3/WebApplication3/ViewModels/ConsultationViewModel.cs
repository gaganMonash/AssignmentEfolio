using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Helper;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class ConsultationViewModel
    {
        public Consultation cons { get; set; }
        public List<Consultation> consultation { get; set; }
        //public List<Doctor> doctors { get; set; }

        //public List<Patient> patient { get; set; }
        public string userRole { get; set; }

        public Utility1 helper = new Utility1();
    }
    public class RatingViewModel
    {
        public string userRole { get; set; }
        public List<Review> review { get; set; }
        public Utility1 helper = new Utility1();
        public Review ratereview { get; set; }
        public string docName { get; set; }

    }
}