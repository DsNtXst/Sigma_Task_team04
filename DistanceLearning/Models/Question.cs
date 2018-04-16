using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistanceLearning.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public string Task { get; set; }

        public string TrueAnswer { get; set; }

        public List<string> Answers { get; set; }
    }
}