using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DistanceLearning.Models;

namespace DistanceLearning.Web.Models
{
    public class Lector
    {
        [Key]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string Password { get; set; }

        public List<Course> Courses { get; set; }
    }
}