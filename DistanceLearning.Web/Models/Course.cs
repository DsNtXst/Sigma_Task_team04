using System.Collections.Generic;
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

        public Lector LectorId { get; set; }


        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}