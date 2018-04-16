using System.Data.Entity;
using DistanceLearning.Models;

namespace DistanceLearning.Web.Models
{
    public class DistanceLearningContext : DbContext
    {
        public DistanceLearningContext() 
            :base("DefaultConnection"){ }

        public DbSet<Lector> Lectors { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }
    }
}