using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DistanceLearning.Web.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Question> Questions { get; set; }

        public int CountQuestions { get; set; }

        public TimeSpan Time { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}