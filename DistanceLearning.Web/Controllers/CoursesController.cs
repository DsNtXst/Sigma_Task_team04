using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Web.Models;
using System.Data.Entity;

namespace DistanceLearning.Web.Controllers
{
    public class CoursesController : Controller
    {
        ApplicationUserContext db = new ApplicationUserContext();

        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult MyCourses()
        {
            IEnumerable<Course> courses = db.Courses;

            //var claims = User.Identity as ClaimsIdentity;
            //var userId = claims.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //var userIdValue = userId.Value;

            string Current = User.Identity.Name;

            ViewBag.Courses = courses.Where(o => o.LectorEmail == Current);
            return View();
        }

        [Authorize]
        [Authorize(Roles = "user")]
        public ActionResult AllCourses()
        {
            IEnumerable<Course> courses = db.Courses;
            ViewBag.Courses = courses;
            return View();
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            ViewBag.LectorEmail = User.Identity.Name;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            BusinessLayer.Mail.SendMail("yakushew.denis@gmail.com", course.Name);
            return RedirectToAction("MyCourses", "Courses");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            Course b = db.Courses.Find(Id);

            if (b == null)
            {
                return HttpNotFound();
            }

            db.Courses.Remove(b);
            db.SaveChanges();

            return RedirectToAction("MyCourses", "Courses");
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int Id)
        {
            Course course = db.Courses.Find(Id);
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Course/" + course.Id);
        }

        [Authorize]
        public ActionResult Course(int Id)
        {
            var course = db.Courses.Find(Id);

            IEnumerable<Test> tests = db.Tests.Where(j => j.CourseId == Id);

            ViewBag.Tests = tests;

            return View(course);

        }
    }
}