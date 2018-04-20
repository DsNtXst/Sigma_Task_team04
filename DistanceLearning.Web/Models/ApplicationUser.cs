using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DistanceLearning.Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string MiddleName { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public ApplicationUser()
        {

        }
    }
}