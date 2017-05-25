using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Медиа_сеть_маркетинговой_компании.Models;
using System.Data.Entity;

namespace Медиа_сеть_маркетинговой_компании
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UserContext uc = new UserContext();
            //uc.Database.CreateIfNotExists();
            uc.Database.Delete();
            uc.Database.CreateIfNotExists();
            Role r = new Role(); r.Name = "Admin"; uc.Roles.Add(r); uc.SaveChanges();
            User u = new User(); u.Email = "SuperAdmin"; u.Password = "Admin"; u.RoleId = 1; uc.Users.Add(u);uc.SaveChanges();
            Role z = new Role();z.Name = "User"; uc.Roles.Add(z);uc.SaveChanges();
            Profile p = new Profile();p.Date_r = DateTime.Now; p.Date_s = DateTime.Now;p.FirstName = "SuperAdmin";
            p.LastName = "SuperAdminov";
            p.Id = 1;
            p.Age = 18;
            uc.SaveChanges();
            uc.Profiles.Add(p);
            uc.SaveChanges();
            uc.Users.Add(new Models.User { Email = "ban", Password = "123456", RoleId = 2 });
            uc.SaveChanges();
            uc.Profiles.Add(new Profile { Date_r = DateTime.Now, Date_s = DateTime.Now, FirstName = "asdsa", LastName = "asd", Age = 22, Id = 2 });
            uc.SaveChanges();
            uc.Bans.Add(new Ban { UserId = 2, Date_b = DateTime.Now, Date_unb = DateTime.Now.AddDays(20), Reason = "raq" });
            uc.SaveChanges();
            uc.Database.CreateIfNotExists();
            uc.Cats.Add(new Cat { Name = "Реклама", id = 0 });
            uc.SaveChanges();
            uc.adverts.Add(new Advert { CatsId = 0, UserId = 1, msg = "asdasda" });
            uc.SaveChanges();
        }
    }
}
