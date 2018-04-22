using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DistanceLearning.Web.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Hours { get; set; }

        public Test Exam { get; set; }

        public int Mark { get; set; }

        public string LectorEmail { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<Test> Tests { get; set; }

        //21 04
        public virtual ICollection<ApplicationUser> People { get; set; }

    }
}