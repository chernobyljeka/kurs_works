using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Медиа_сеть_маркетинговой_компании.Models;
using System.Data.Entity;

namespace Медиа_сеть_маркетинговой_компании.Controllers
{
    public class RoomController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            UserContext uc = new UserContext();
            var id = uc.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id;
            return View(uc.adverts.Where(u=>u.UserId==id).ToList());
        }
        [Authorize]
        [HttpGet]
        public ActionResult AddAdvert()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddAdvert(Advert a)
        {
            if (ModelState.IsValid)
            {
                UserContext uc = new UserContext();
                var p = uc.Profiles.Where(u => u.Id == uc.Users.Where(uu => uu.Email == User.Identity.Name).FirstOrDefault().Id).FirstOrDefault();
                if (p.Balance > 100)
                {
                    p.Balance -= 100;
                    a.UserId = uc.Users.Where(u=>u.Email==User.Identity.Name).FirstOrDefault().Id;
                    uc.adverts.Add(a);
                    uc.SaveChanges();
                    uc.Entry(p).State = EntityState.Modified;
                    uc.SaveChanges();
                    return RedirectToAction("Index", "Room");
                }
                else
                {
                    ModelState.AddModelError("1", "У вас не достаточно средств на счету");
                }
            }
            return View(a);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Cash()
        {
            UserContext uc = new UserContext();
            ViewBag.A = uc.Profiles.Where(uu => uu.Id == (uc.Users.Where(u => u.Email == User.Identity.Name).FirstOrDefault().Id)).FirstOrDefault().Balance;
            return View();
        }
    }
}