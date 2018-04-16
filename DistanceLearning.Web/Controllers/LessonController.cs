﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistanceLearning.Models;
using DistanceLearning.Web.Models;


namespace DistanceLearning.Web.Controllers
{
    public class LessonController : Controller
    {
        DistanceLearningContext db = new DistanceLearningContext();

        //не надо-есть в курсах
        //вывод всех уроков у курса
        /*public ActionResult ViewLesson(int Id_course)
        {
            IEnumerable<Lesson> lessons;

            lessons = db.Lessons.Where(l => l.CourseId == Id_course).ToList();
            ViewBag.Lessons = lessons;



            return View();
        }*/

        
        //вывод формы добавление урока
        [HttpPost]
        public ActionResult ViewLessonAdd(int Id_course)
        {
            ViewBag.Id_course = Id_course;

            return View();

        }



        //добавление урока
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(Lesson lesson)
        {
            db.Lessons.Add(lesson);

            db.SaveChanges();

            return RedirectToAction("Course", "Courses",new { Id= lesson.CourseId });

        }


        [HttpGet]
        //вывод формы Об уроке
        public ActionResult ViewLessonAbout(int id_lesson)
        {
            var lesd = db.Lessons.Where(l => l.Id == id_lesson).FirstOrDefault();
            ViewBag.OneLesson = lesd;

            return View();

        }

        [HttpPost]
        //удаление урока
        public ActionResult Delete(int id_lesson)
        {
            Lesson les = db.Lessons.Where(l => l.Id == id_lesson).FirstOrDefault();

            db.Lessons.Remove(les);

            db.SaveChanges();

            return RedirectToAction("Course", "Courses", new { Id = les.CourseId });

        }
        [HttpPost]
        //вывод формы редактирование
        public ActionResult ViewLessonEdit(int id_lesson)
        {
           var lesd = db.Lessons.Where(l => l.Id == id_lesson).FirstOrDefault();
            ViewBag.OneLesson = lesd;

            return View();

        }

        [HttpPost]
        [ValidateInput(false)]
        //изменение урока
        public ActionResult Update(Lesson lesson)
        {
            Lesson les = db.Lessons.Where(l => l.Id == lesson.Id).FirstOrDefault();
            les.Information = lesson.Information;
            les.Name = lesson.Name;

            db.SaveChanges();

            return RedirectToAction("ViewLessonAbout","Lesson", new {id_lesson=les.Id});

        }

    }
}
