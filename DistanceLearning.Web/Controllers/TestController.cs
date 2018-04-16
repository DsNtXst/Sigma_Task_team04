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

        DistanceLearningContext db = new DistanceLearningContext();

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
        //вывод формы О тесте
        public ActionResult ViewTestAbout(int id_test)
        {
            var tesd = db.Tests.Where(l => l.Id == id_test).FirstOrDefault();
            ViewBag.OneTest = tesd;
            return View();

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
            return RedirectToAction("ViewTestAbout", "Test", new { id_test = tes.Id });

        }

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
    }
}