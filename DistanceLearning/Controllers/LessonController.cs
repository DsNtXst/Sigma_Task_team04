using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Models;
namespace DistanceLearning.Controllers
{
    public class LessonController : Controller
    {
        DistanceLearningContextLesson db = new DistanceLearningContextLesson();

        Lesson lesd;
        //вывод всех уроков
        public ActionResult ViewLesson()
        {

           
                IEnumerable<Lesson> lessons = db.Lessons;

                ViewBag.Lessons = lessons;
                return View();
            
        }
  
        //вывод формы добавление урока
        public ActionResult ViewLessonAdd()
        {
            
            return View();

        }
        [HttpPost]
        //добавление урока
        public ActionResult Add(Lesson lesson)
        {
                db.Lessons.Add(lesson);

                db.SaveChanges();

                return RedirectToAction("ViewLesson");
          
        }
        
        [HttpPost]
        //удаление урока
        public ActionResult Delete(int id_lesson)
        {
            Lesson les = db.Lessons.Where(l => l.Id == id_lesson).FirstOrDefault();

            db.Lessons.Remove(les);

            db.SaveChanges();

            return RedirectToAction("ViewLesson");

        }

        [HttpGet]  
        //вывод формы Об уроке
        public ActionResult ViewLessonAbout(int id_lesson)
        {       
            lesd = db.Lessons.Where(l => l.Id == id_lesson).FirstOrDefault();
            ViewBag.OneLesson = lesd;

            return View();

        }
        [HttpPost]
        //вывод формы редактирование
        public ActionResult ViewLessonEdit(int id_lesson)
        {
            lesd = db.Lessons.Where(l => l.Id == id_lesson).FirstOrDefault();
            ViewBag.OneLesson = lesd;

            return View();

        }

        [HttpPost]
        //изменение урока
        public ActionResult Update(Lesson lesson)
        {
            Lesson les = db.Lessons.Where(l => l.Id == lesson.Id).FirstOrDefault();
            les.Information = lesson.Information;
            les.Name = lesson.Name;

            db.SaveChanges();

            return RedirectToAction("ViewLesson");

        }

    }
}
