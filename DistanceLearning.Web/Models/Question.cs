using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DistanceLearning.Web.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Task { get; set; }

        public string TrueAnswer { get; set; }

        public string WrongAnswer1 { get; set; }

        public string WrongAnswer2 { get; set; }

        public string WrongAnswer3 { get; set; }

        public int? TestId { get; set; }

        public virtual Test Test { get; set; }

    }
}