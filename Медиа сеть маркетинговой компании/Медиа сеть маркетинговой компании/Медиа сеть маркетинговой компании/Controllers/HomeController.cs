using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Медиа_сеть_маркетинговой_компании.Models;
using System.Data.Entity;

namespace Медиа_сеть_маркетинговой_компании.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            UserContext uc = new UserContext();
            User u = uc.Users.Find(1);
            uc.Entry(u).State = EntityState.Modified;
            uc.SaveChanges();
            return View();
        }
        [HttpGet]
        public void SendMsg()
        {

        }
    }
}