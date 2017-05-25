using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Медиа_сеть_маркетинговой_компании.Models;
using System.Data.Entity;


namespace Медиа_сеть_маркетинговой_компании.Controllers
{
    public class AdminController : Controller
    {
        UserContext uc = new UserContext();
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            UserContext cc = new UserContext();
            return View(cc.adverts.Where(u => u.id > -1).ToList());
        }
        [Authorize]
        [HttpGet]
        public ActionResult Stats()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult ListAdverts()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public ActionResult ListCat()
        {
            UserContext cc = new UserContext();
            return View(cc.Cats.Where(u => u.id > -1).ToList());
        }
        [Authorize]
        [HttpGet]
        public ActionResult DelCat(int id)
        {
            UserContext cc = new UserContext();
            cc.Cats.Remove(cc.Cats.Find(id));
            cc.SaveChanges();
            return RedirectToAction("ListCat","Admin");
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddCat()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddCat(Cat c)
        {
            UserContext cc = new UserContext();
            cc.Cats.Add(c);
            cc.SaveChanges();
            return RedirectToAction("ListCat", "Admin");
        }
        [Authorize]
        [HttpGet]
        public ActionResult ListUsers()
        {
            UserContext uc = new UserContext();
            List<User> uu = new List<Models.User>();
            uu = uc.Users.Where(u => u.Id != -1).ToList();
            return View(uu);
        }
        [Authorize]
        [HttpGet]
        public ActionResult RegUser()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult RegUser(RegisterModel u)
        {
            UserContext uc = new UserContext();
            User uu = new Models.User();
            uu.Email = u.Name;
            uu.Password = u.Password;
            uu.RoleId = 1;
            uc.Users.Add(uu);
            uc.SaveChanges();
            uu=uc.Users.Where(uuu => uuu.Email == u.Name).FirstOrDefault();
            uc.Profiles.Add(new Models.Profile { Id = uu.Id, Date_r = DateTime.Now, Date_s = DateTime.Now, FirstName = u.FName, LastName = u.LName, Balance = 100,Age=u.Age });
            uc.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        [Authorize]
        [HttpGet]
        public ActionResult DelUser(int id)
        {
            UserContext uc = new UserContext();
            uc.Users.Remove(uc.Users.Find(id));
            uc.Profiles.Remove(uc.Profiles.Where(u=>u.Id==id).FirstOrDefault());
            uc.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
        [Authorize]
        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            UserContext uc = new UserContext();
            return View(uc.Users.Where(u=>u.Id==id).FirstOrDefault());
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditUser(User u)
        {
            UserContext uc = new UserContext();
            uc.Entry(u).State = EntityState.Modified;
            uc.SaveChanges();
            return RedirectToAction("Index","Admin");
        }
    }
}