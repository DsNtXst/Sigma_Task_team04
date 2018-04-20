//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System.Data.Entity;

//namespace DistanceLearning.Web.Models
//{
//    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationUserContext>
//    {
//        protected override void Seed(ApplicationUserContext context)
//        {
//            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

//            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

//            // создаем две роли
//            var role1 = new IdentityRole { Name = "admin" };
//            var role2 = new IdentityRole { Name = "user" };

//            // добавляем роли в бд
//            roleManager.Create(role1);
//            roleManager.Create(role2);

//            // создаем пользователей
//            var admin = new ApplicationUser { Email = "admin@admin.admin", UserName = "admin@admin.admin" };
//            string password = "adminadmin";
//            var result = userManager.Create(admin, password);

//            // если создание пользователя прошло успешно
//            if (result.Succeeded)
//            {
//                // добавляем для пользователя роль
//                userManager.AddToRole(admin.Id, role1.Name);
//            }

//            var user = new ApplicationUser { Email = "test@test.test", UserName = "test@test.test" };
//            password = "testtest";
//            result = userManager.Create(user, password);

//            // если создание пользователя прошло успешно
//            if (result.Succeeded)
//            {
//                // добавляем для пользователя роль
//                userManager.AddToRole(user.Id, role2.Name);
//            }

//            base.Seed(context);
//        }
//    }
//}