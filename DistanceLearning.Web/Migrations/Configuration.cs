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

            List<string> A1 = new List<string>();
            A1.Add("f");
            A1.Add("z");
            A1.Add("t");
            A1.Add("y");



            var questions = new List<Question>
            {
               new Question
               {
                   Id=1,Task="�����",TrueAnswer="f",Answers=A1
               }
            };
            questions.ForEach(s => context.Questions.Add(s));
            context.SaveChanges();

            var tests = new List<Test>
            {
                new Test
               {
                   Id =1, CountQuestions=1,Name="������",CourseId=3,Time=TimeSpan.Parse("00:20:00"),Questions=questions
               }
            };
            tests.ForEach(s => context.Tests.Add(s));
            context.SaveChanges();
        }
    }
}
