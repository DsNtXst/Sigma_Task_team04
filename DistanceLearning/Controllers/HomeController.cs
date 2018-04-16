using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Models;

namespace DistanceLearning.Controllers
{
    public class HomeController : Controller
    {
        DistanceLearningContextLesson db = new DistanceLearningContextLesson();

        public ActionResult Index()
        {
            // получаем из бд все объекты Course
            IEnumerable<Course> courses = db.Courses;
            // передаем все объекты в динамическое свойство Courses в ViewBag

            ViewBag.Courses = courses;
            // возвращаем представление
            return View();
        }
    }
}