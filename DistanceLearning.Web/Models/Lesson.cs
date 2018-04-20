using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DistanceLearning.Web.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Information { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}