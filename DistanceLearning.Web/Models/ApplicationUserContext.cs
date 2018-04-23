using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DistanceLearning.Web.Models;

namespace DistanceLearning.Web.Models
{
    public class ApplicationUserContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationUserContext() : base("base") { }

        public static ApplicationUserContext Create()
        {
            return new ApplicationUserContext();
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }

        //22 04
        //public DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>()
           .HasOptional<Test>(s => s.Test)
           .WithMany()
           .WillCascadeOnDelete(false);
            //---modelBuilder.Entity<Test>().HasOptional(a => a.Questions).WithOptionalDependent().WillCascadeOnDelete(true);
        }
    }
}