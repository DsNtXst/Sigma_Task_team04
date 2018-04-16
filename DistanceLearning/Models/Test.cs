using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistanceLearning.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Question> Questions { get; set; }

        public int CountQuestions { get; set; }

        public TimeSpan Time { get; set; }
    }
}