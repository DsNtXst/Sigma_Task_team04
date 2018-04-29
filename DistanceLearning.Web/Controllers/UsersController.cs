using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
//
using DistanceLearning.Web.Models;

namespace DistanceLearning.Web.Controllers
{
    public class UsersController : Controller
    {
        ApplicationUserContext db = new ApplicationUserContext();

        //подписаться на курс
        [HttpPost]
        [Authorize(Roles = "user")]
        public ActionResult SubscribeOnCourse(int Course_id)
        {

            Course cour = db.Courses.Find(Course_id);

            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());

            user.Courses.Add(cour);
            db.SaveChanges();


            //return RedirectToAction("Course", "Courses", new { Id = Course_id });
            return RedirectToAction("ViewSuccessMessage",  new { Course_id = Course_id });

        }

        //отписаться от курс
        [HttpPost]
        [Authorize(Roles = "user")]
        public ActionResult LeaveCourse(int Course_id)
        {
            //Course cour = db.Courses.Find(Course_id);


            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            Course cour = user.Courses.Where(l => l.Id == Course_id).FirstOrDefault();

            user.Courses.Remove(cour);

            //db.SaveChanges();

            //29 04 -удаляем результаты при отписке
            IEnumerable<Test> tests = db.Tests.Where(j => j.CourseId == Course_id);//вытаскиваем тесты принадлежащие курсу
            IEnumerable<Result> rez = db.Results.Where(r=>r.UserEmail==this.User.Identity.Name);//вытаскиваем результаты принадлежащие студенту

            foreach(Result r in rez )
            {
                //if(r.TestId==tests.Where(t=>t.Id==))
                bool include = false;

                    foreach(Test t in tests)
                    {
                        if (r.TestId == t.Id)
                        { include = true;
                        break;
                        }

                    }

                    if(include)
                    {
                    db.Results.Remove(r);

                    }




            }

            db.SaveChanges();


            return RedirectToAction("Course", "Courses", new { Id = Course_id });

        }


        //
        //[HttpPost]
        [Authorize(Roles = "user")]
        public ActionResult ViewSuccessMessage(int Course_id)
        {
            ViewBag.IDcourse = Course_id;


            return View();

        }

        [Authorize(Roles = "user")]
        public ActionResult ViewUserCourses()
        {

            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());

            ViewBag.Courses = user.Courses;


            return View(/*user.Courses*/);

        }

    }
}