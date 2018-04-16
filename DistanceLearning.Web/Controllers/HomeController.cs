using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Models;
using DistanceLearning.Web.Models;

namespace DistanceLearning.Web.Controllers
{
    public class HomeController : Controller
    {
        DistanceLearningContext db = new DistanceLearningContext();

        public ActionResult Index()
        {
            IEnumerable<Course> courses = db.Courses;

            ViewBag.Courses = courses;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}