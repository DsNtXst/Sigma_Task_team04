using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearning.Web.Models
{
    public static class CourseCRUD
    {
        public static void DeleteOne(ref ApplicationUserContext db, int Id)
        {
            Course courses = db.Courses.Where(o => o.Id == Id).FirstOrDefault();
            db.Courses.Remove(courses);
            db.SaveChanges();
        }

    }
}