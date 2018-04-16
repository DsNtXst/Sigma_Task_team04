using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistanceLearning.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Hours { get; set; }

        public List<Lesson> Lessons { get; set; }

        public List<Test> Tests { get; set; }

        public Test Exam { get; set; }

        public int Mark { get; set; }
    }
}