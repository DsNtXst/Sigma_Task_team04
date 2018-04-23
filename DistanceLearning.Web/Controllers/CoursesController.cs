using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Web.Models;
using System.Data.Entity;
//
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DistanceLearning.Web.Controllers
{
    public class CoursesController : Controller
    {
        ApplicationUserContext db = new ApplicationUserContext();

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

       // [Authorize(Roles = "user")]
        public ActionResult AllCourses()
        {
            if (this.User.IsInRole("admin")) return RedirectToAction("MyCourses", "Courses");//23 04 -чтобы избавиться от ситуации когда админ не может попасть на MyCourses
            return View(db.Courses.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            ViewBag.LectorEmail = User.Identity.Name;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Add(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
            BusinessLayer.Mail.SendMail("yakushew.denis@gmail.com", course.Name);
            return RedirectToAction("MyCourses", "Courses");
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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

            //22 04
            //проверяем-подписан ли студент на курс
            if (this.User.IsInRole("user"))
            {
                ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
                var cour = user.Courses.Where(l => l.Id == Id).FirstOrDefault();

                bool isSubcribe = false;

                if (cour != null)
                {
                    isSubcribe = true;
                }

                ViewBag.IsSubcribe = isSubcribe;
            }


            return View(course);

        }
    }
}