using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DistanceLearning.Models
{
    public class DistanceLearningDbInitializer : DropCreateDatabaseAlways<DistanceLearningContextLesson>
    {
        protected override void Seed(DistanceLearningContextLesson db)
        {
            db.Courses.Add(new Course { Id = 1, Name = "Базы данных", Hours = 15, Exam = null, Lessons = null, Mark =0, Tests =null });
            db.Courses.Add(new Course { Id = 2, Name = "ООП", Hours = 23, Exam = null, Lessons = null, Mark = 0, Tests = null });
            db.Lessons.Add(new Lesson { Id = 2, Name = "Урок 2.Глава 1", Information = "Информация о уроке 2" });
            db.Lessons.Add(new Lesson { Id = 3, Name = "Урок 3.Глава 2", Information = "Информация о уроке 3" });
            base.Seed(db);
        }

    }
}