using System.Collections.Generic;
using DistanceLearning.Web.Models;
namespace DistanceLearning.Web.Migrations

{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DistanceLearning.Web.Models.ApplicationUserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DistanceLearning.Web.Models.ApplicationUserContext";
        }

        protected override void Seed(DistanceLearning.Web.Models.ApplicationUserContext context)
        {
           
        }
    }
    }

