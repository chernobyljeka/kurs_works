using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Медиа_сеть_маркетинговой_компании.Models;
using System.Data.Entity;

namespace Медиа_сеть_маркетинговой_компании.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                        user = db.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);
                }
                if (user != null)
                {
                    Profile p = null;
                    using (UserContext db = new UserContext())
                    {
                        Ban b = null;
                        b = db.Bans.Where(u => u.UserId == user.Id).FirstOrDefault();
                        if (b != null)
                        {
                            ModelState.AddModelError("", "Вы забанены. До конца бана осталось" + (b.Date_unb - DateTime.Now).Hours.ToString() + "часов.Причина бана " + b.Reason);
                        }
                        else
                        {
                            p = db.Profiles.Where(u => u.Id == user.Id).FirstOrDefault();
                            p.Date_s = System.DateTime.Now;
                            db.Entry(p).State = EntityState.Modified;
                            db.SaveChanges();
                            FormsAuthentication.SetAuthCookie(model.Name, true);
                            if (user.RoleId == 2)
                            {
                                return RedirectToAction("Index", "Room");
                            }
                            else
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                        }
                    }
            }
            else
            {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
            }
        }
            return View(model);

        }
        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name);
                }
                if (user == null)
                {
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new User { Email = model.Name, Password = model.Password, RoleId = 2 });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();
                    }
                    
                    if (user != null)
                    {
                        using (UserContext db = new UserContext())
                        {
                            db.Profiles.Add(new Profile { Date_r = System.DateTime.Now, Date_s = System.DateTime.Now, FirstName = model.FName, LastName = model.LName, Id = user.Id, Age = model.Age, Balance =150  });
                            db.SaveChanges();
                        }
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }
        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Me()
        {
            UserContext uc = new UserContext();
            return View(uc.Profiles.Where(p => p.Id == uc.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id).FirstOrDefault());
        }
        [HttpPost]
        [Authorize]
        public ActionResult Me(Profile p)
        {
            UserContext db = new UserContext();
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}