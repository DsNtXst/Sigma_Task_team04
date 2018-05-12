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

            //30 04 результаты
            IEnumerable < Result > rezults=db.Results.Where(r=>r.UserEmail==this.User.Identity.Name);//все результаты

            IEnumerable<Exam> exams = db.Tests.OfType<Exam>();//cost -все екзамены

            //отделяем екзамены от тестов
            Queue<Result> exz_rezults = new Queue<Result>();//результаты только екзаменов

            foreach(Course c in user.Courses)//2
            {

                //Exam ex=c.Tests.OfType<Exam>().FirstOrDefault();//почему то нет связи --тесты равны 0


                Exam ex = exams.Where(e => e.CourseId == c.Id).FirstOrDefault();//cost
                if (ex!=null)
                {
                    bool IsExamPassed = false;
                    foreach(Result r in rezults)
                    {
                        if(r.TestId==ex.Id)
                        {
                            IsExamPassed = true;
                            exz_rezults.Enqueue(r);
                            break;

                        }

                    }
                    if(!IsExamPassed)
                    {
                        Result false_rezult = new Result();
                        false_rezult.Status = 55;
                        exz_rezults.Enqueue(false_rezult);
                      

                    }

                }
                


            }
            

            ViewBag.exz_rezults = exz_rezults;
            
            return View(/*user.Courses*/);

        }

    }
}