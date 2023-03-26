using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Data;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext context;
        public LoginController() {
            context = new DataContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                var userExists = (from u in context.Users
                            where u.Email.Equals(user.Email)
                            && u.Password.Equals(user.Password)
                            select u).SingleOrDefault();
                Console.WriteLine(userExists);
                if (userExists != null)
                {
                    Session["user"] = user;

                    return RedirectToAction("Index", "Home");
                }

                TempData["Error"] = "Invalid Credentials";
            }

            return View(user);
        }

        public ActionResult Invalidate()
        {
            Session["user"] = null;

            return RedirectToAction("Index", "Login");
        }
    }
}