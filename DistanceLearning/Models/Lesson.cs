using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistanceLearning.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Information { get; set; }
    }
}