using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Web.Models;

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
            return View();

        }

        //добавление теста
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Test test)
        {
            db.Tests.Add(test);
            db.SaveChanges();
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
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
    }
}