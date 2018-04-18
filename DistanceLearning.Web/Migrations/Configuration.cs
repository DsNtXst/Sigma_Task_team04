using System.Collections.Generic;
using DistanceLearning.Web.Models;

namespace DistanceLearning.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DistanceLearningContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DistanceLearning.Models.DistanceLearningContext";
        }

        protected override void Seed(DistanceLearningContext context)
        {
            var courses = new List<Course>
            {
                new Course { Id = 3, Name = "First course", Hours = 15 },
                new Course { Id = 4, Name = "Second course", Hours = 23}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var lessons = new List<Lesson>
            {
               new Lesson
               {
                   Id =1, Information = "Fisrt Lesson", Name = "Lesson 1", CourseId = 3
               },
               new Lesson
               {
                   Id= 2, Information = "Secon Lesson", Name = "Lesson 2", CourseId =3
               },
                new Lesson
                {
                    Id =1, Information = "Fisrt Lesson", Name = "Lesson 1", CourseId = 4
                },
                new Lesson
                {
                    Id= 2, Information = "Secon Lesson", Name = "Lesson 2", CourseId = 4
                }
            };
            lessons.ForEach(s => context.Lessons.Add(s));
            context.SaveChanges();




            var quest = new List<Question>
            {
               new Question
               {
                   Id=1,Task="*uck",TrueAnswer="D",WrongAnswer1="U",WrongAnswer2="g",WrongAnswer3="t",TestId=1
               }
            };
            quest.ForEach(s => context.Questions.Add(s));
            context.SaveChanges();

            int idd = 1;
            var tests = new List<Test>
            {
                new Test
               {
                   Id = 1, CountQuestions=1 ,Name="Модуль",CourseId=3,Time=TimeSpan.Parse("00:20:00"),Questions=quest
        }
            };
            tests.ForEach(s => context.Tests.Add(s));
            context.SaveChanges();
        }
    }
}
