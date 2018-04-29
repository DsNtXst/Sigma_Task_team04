using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//
using DistanceLearning.Web.Models;

namespace DistanceLearning.Web.Controllers
{
    public class LectorController : Controller
    {

        ApplicationUserContext db = new ApplicationUserContext();

        [Authorize(Roles = "admin")]
        public ActionResult ViewLectorCabinet()
        {
            IEnumerable<Course> hisCourses=db.Courses.Where(c=>c.LectorEmail==this.User.Identity.Name);//курсы только данного лектора

            IEnumerable<Exam> exams = db.Tests.OfType<Exam>();//все екзамены

            List<Exam> hisExams = new List<Exam>();//екзамены принадлежащие только его курсам 

            
            foreach(Exam e in exams)
            {
                bool ishisexam = false;

                foreach (Course c in hisCourses)
                {
                    if(e.CourseId==c.Id)
                    {

                        ishisexam = true;
                        break;
                    }
                }
                if(ishisexam)
                {
                    hisExams.Add(e);
                }

            }

            IEnumerable<Result> rezults = db.Results.Where(re=>re.Status==0);//все результаты со статусом 0


            List<Result> ekzRez = new List<Result>();//результаты только екзаменов

            foreach (Result r in rezults)//отловим только результаты экзаменов
            {
                bool include = false;

                foreach (Exam e in hisExams)
                {
                    if (e.Id == r.TestId)
                    {
                        include = true;
                        break;
                    }

                }

                if(include)
                {
                    ekzRez.Add(r);

                }
            }

            //обратн-каким курсам принадл результаты
            Queue<string> courses_names = new Queue<string>();

            foreach (Result r in ekzRez)
            {

                foreach(Exam e in hisExams)
                {
                    if(r.TestId==e.Id)
                    {
                        Course cour = hisCourses.Where(h => h.Id == e.CourseId).FirstOrDefault();
                        courses_names.Enqueue(cour.Name);
                       
                        break;

                    }

                }
                    
            }

                ViewBag.ekzRez = ekzRez;
                ViewBag.courses_names = courses_names;


            return View();

        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AcceptRezult(int rezId)//подтвердить результат экзамена
        {

            Result r = db.Results.Where(re => re.Id == rezId).FirstOrDefault();
            r.Status = 1;
            db.SaveChanges();

            return RedirectToAction("ViewLectorCabinet");
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult RejectRezult(int rezId)//опровергнуть
        {
            Result r = db.Results.Where(re => re.Id == rezId).FirstOrDefault();
            r.Status = 2;
            db.SaveChanges();


            return RedirectToAction("ViewLectorCabinet");
        }




    }
}