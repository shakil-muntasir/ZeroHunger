using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Middlewares;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return View();
            }

            return RedirectToAction("Index", "Login");
        }
    }
}