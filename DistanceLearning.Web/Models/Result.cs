using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace DistanceLearning.Web.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        public string UserEmail { get; set; }

        public int TestId { get; set; }

        public double Progress { get; set; }
        //
        public byte Status { get; set; }
    }
}