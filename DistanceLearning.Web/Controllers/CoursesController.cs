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

            //IEnumerable<Test> tests = db.Tests.Where(j => j.CourseId == Id);

            

            //27 04
            IEnumerable<Test> tests = db.Tests.Where(j => j.CourseId == Id);
            IEnumerable<Exam> exams = tests.OfType<Exam>();

#region какие тесты пройденны ч1
            //28 04
            List<int> id_passed_tests=new List<int>();
                #endregion

                ViewBag.Exam = exams;
            ViewBag.Tests = tests;




            //22 04
#region проверяем-подписан ли студент на курс
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
    
            //27 04
#region проверяем все ли тесты прошел


            //ViewBag.Ability = CheckAbilityPassingExam(Id,tests);


            int count_of_test = tests.Count();//общее число тестов на курсе
            int count_passed = 0;//количество прошедших тестов

            IEnumerable<Result> rez = db.Results;

        

            //находим результат--находим тест--находим курс
            foreach (Result it in rez)
            {
                if (this.User.Identity.Name == it.UserEmail)
                {
                    Test test = tests.Where(l => l.Id == it.TestId).FirstOrDefault();



                    if (test != null)
                    {
                       Course cour2 = db.Courses.Find(test.CourseId);


                        if (course.Id == cour2.Id)
                        {
                            count_passed++;
#region какие тесты пройденны ч2
                                //28 04
                                id_passed_tests.Add(test.Id);
                                //k 28 04
#endregion
                                #region прверяем прошел ли екзамен

                                if ((test.GetType().ToString()).Contains("Exam"))
                            {
                                ViewBag.ExamPassed = true;
                            }
                            else
                            {
                                ViewBag.ExamPassed = false;
                            }

#endregion

                        }
                    }
                }
            }

            if (count_passed == count_of_test - 1) ViewBag.Ability = true;
            else ViewBag.Ability = false;
#endregion

            }
#endregion
            if(ViewBag.ExamPassed ==null) ViewBag.ExamPassed =false;

           
            ViewBag.id_passed_tests = id_passed_tests;



            return View(course);



        }



        //27/04 проверяет давать возможность пройти тест
        //bool CheckAbilityPassingExam(int CourseId, IEnumerable<Test> tests)
        //{
        //    Course current= db.Courses.Find(CourseId);
        

        //    int count_of_test= tests.Count();//общее число тестов на курсе
        //    int count_passed = 0;//количество прошедших тестов

        //    IEnumerable<Result> rez = db.Results;


        //    //находим результат--находим тест--находим курс
        //    foreach (Result it in rez )
        //    {
        //        if (this.User.Identity.Name == it.UserEmail)
        //        {
        //            //Test test = db.Tests.Find(it.TestId);

        //            //Course course = db.Courses.Find(test.CourseId);

        //            Test test = tests.Where(l => l.Id == it.TestId).FirstOrDefault();
        //            Course course = db.Courses.Where(c=>c.Id==test.CourseId).FirstOrDefault();

        //            if (course.Id == current.Id)
        //                count_passed++;
        //        }
        //    }

        //    if (count_passed == count_passed - 1) return true;

        //    return false;
        //}
    }
}