using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DistanceLearning.Web.Models;

namespace DistanceLearning.Web.Controllers
{
    public class CoursesController : Controller
    {
        readonly DistanceLearningContext context = new DistanceLearningContext();

        public ActionResult Course(int Id)
        {
                var course = context.Courses.Find(Id);

                IEnumerable<Test> tests = context.Tests.Where(j => j.CourseId == Id);

                ViewBag.Tests = tests;

                return View(course);

        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {
                Course b = context.Courses.Find(Id);

                if (b == null)
                {
                    return HttpNotFound();
                }

                context.Courses.Remove(b);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
                Course course = context.Courses.Find(Id);
                return View(course);
        }

        

        [HttpPost]
        public ActionResult Edit(Course course)
        {
                context.Entry(course).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Course/" + course.Id);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Course course)
        {
                context.Courses.Add(course);
                context.SaveChanges();
                Mail.Mail.SendMail("yakushew.denis@gmail.com", course.Name);
                return RedirectToAction("Index", "Home");
        }
    }
}