using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = "Patient")]
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }
    }
}