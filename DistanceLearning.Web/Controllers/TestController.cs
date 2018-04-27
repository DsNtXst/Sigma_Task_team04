using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Web.Models;
using Microsoft.AspNet.Identity;

namespace DistanceLearning.Web.Controllers
{
    public class TestController : Controller
    {
        ApplicationUserContext db = new ApplicationUserContext();

        Test tesd;
        //вывод формы добавление теста
        [HttpPost]
        public ActionResult ViewTestAdd(int Id_course)
        {
            ViewBag.Id_course = Id_course;


            //27 04 проверяем-есть ли уже екзамен
            IEnumerable<Test> tests = db.Tests.Where(j => j.CourseId == Id_course);
            IEnumerable<Exam> exams = tests.OfType<Exam>();
            int count = 0;
            //if (exams == null)
            //    ViewBag.OneMoreExam = true;
            //else ViewBag.OneMoreExam = false;
            if (exams != null)
            { count = exams.Count(); }
            if (count == 0)
            { ViewBag.OneMoreExam = true; }
            else
            { ViewBag.OneMoreExam = false; }


            return View();

        }

        //добавление теста
        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult Add(Test test)
        //{
        //    db.Tests.Add(test);
        //    db.SaveChanges();
        //    return RedirectToAction("Course", "Courses", new { Id = test.CourseId });
        //}

        //добавление теста (и екзамена)
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Test test,bool? IsExam)
        {
            
            //27 04-режим екзамен
        


            if(IsExam!=null)
            {
                Exam ex = new Exam();
                ex.IsConfirmed = false;

                ex.CourseId = test.CourseId;
                ex.Name = test.Name;
                ex.Time = test.Time;

                db.Tests.Add(ex);
                db.SaveChanges();
            }
            else
            {
                
                db.Tests.Add(test);
                db.SaveChanges();

            }
            
            return RedirectToAction("Course", "Courses", new { Id = test.CourseId });
        }

        [HttpGet]

        public ActionResult ViewTestAbout(int? id_test)
        {
            var test = db.Tests.Find(id_test);
            IEnumerable<Question> ques = db.Questions.Where(j => j.TestId == id_test);
            //var tesd = db.Tests.Where(l => l.Id == id_test).FirstOrDefault();
            ViewBag.Questions = ques;
            ViewData["ques"] = ques.Count();
            return View(test);

        }
        public ActionResult Delete(int id_test)
        {
            Test tes = db.Tests.Where(l => l.Id == id_test).FirstOrDefault();
            db.Tests.Remove(tes);
            db.SaveChanges();
            return RedirectToAction("Course", "Courses", new { Id = tes.CourseId });

        }
        [HttpPost]
        //вывод формы редактирование
        public ActionResult ViewTestEdit(int id_test)
        {
            var tesd = db.Tests.Where(l => l.Id == id_test).FirstOrDefault();
            ViewBag.OneTest = tesd;
            return View();

        }

        [HttpPost]
        [ValidateInput(false)]
        //изменение урока
        public ActionResult Update(Test test)
        {
            Test tes = db.Tests.Where(l => l.Id == test.Id).FirstOrDefault();
            tes.Name = test.Name;
            tes.CountQuestions = test.CountQuestions;
            tes.Time = test.Time;
            db.SaveChanges();
            return RedirectToAction("ViewTestAbout", "Test", new { id_test = test.Id });

        }
        [HttpPost]
        public ActionResult ViewTestAddQuest(int Id_test)
        {

            ViewBag.Id_test = Id_test;

            return View();

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddQues(Question ques)
        {
            db.Questions.Add(ques);
            db.SaveChanges();
            return RedirectToAction("ViewTestAbout", "Test", new { id_test = ques.TestId });
        }
        [HttpPost]
        //удаление урока
        public ActionResult DeleteQ(int id_question)
        {

            Question ques = db.Questions.Where(l => l.Id == id_question).FirstOrDefault();
            int? cid = ques.TestId;
            db.Questions.Remove(ques);
            db.SaveChanges();
            return RedirectToAction("ViewTestAbout", "Test", new { id_test = cid });

        }

        public ActionResult TestRun(int id_test)
        {
            var test = db.Tests.Find(id_test);
            IEnumerable<Question> ques = db.Questions.Where(j => j.TestId == id_test);
            ViewBag.Questions = ques;
            ViewData["ques"] = ques.Count();
            return View(test);

        }

        [HttpPost]
        public ActionResult TestRun(string[] answer, string[] curr, int TestId)
        {
            double oneP = 100.0 / answer.Length;
            int trueAns = 0;
            for (int i =0;i<answer.Length;i++)
            {
                if (answer[i] == curr[i]) trueAns++;
            }
            double Result = trueAns* oneP;



            Result R = new Result() { TestId = TestId, UserEmail = User.Identity.Name, Progress = Result };


            db.Results.Add(R);
            db.SaveChanges();
            return RedirectToAction("ResultOfTest", "Test", new { k = Result });


        }

        public ActionResult ResultOfTest(double k)
        {
            ViewBag.Res = k;
            return View();
        }


    }
}