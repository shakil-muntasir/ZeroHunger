using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Data;
using ZeroHunger.Models;
using ZeroHunger.Middlewares;

namespace ZeroHunger.Controllers
{
    [Authorization]
    public class ApprovalController : Controller
    {
        private readonly DataContext context;

        public ApprovalController()
        {
            context = new DataContext();
        }

        public ActionResult Index()
        {
            var collections = (from item in context.Collections
                              where item.Status == Status.Pending
                              select item).ToList();

            return View(collections);
        }
    }
}