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
    public class CollectionController : Controller
    {
        private readonly DataContext context;

        public CollectionController()
        {
            context = new DataContext();
        }

        public ActionResult Index()
        {
            var collections = context.Collections.ToList();

            return View(collections);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Collection product)
        {

            context.Collections.Add(product);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var collection = (from item in context.Collections
                           where item.Id == id
                           select item).SingleOrDefault();

            return View(collection);
        }

        [HttpPost]
        public ActionResult Edit(Collection collection)
        {
            var targetCollection = (from item in context.Collections
                                 where item.Id == collection.Id
                                 select item).SingleOrDefault();

            targetCollection.Name = collection.Name;
            targetCollection.Food = collection.Food;
            targetCollection.Quantity = collection.Quantity;
            targetCollection.Expiry = collection.Expiry;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var targetCollection = (from item in context.Collections
                                 where item.Id == id
                                 select item).SingleOrDefault();

            context.Collections.Remove(targetCollection);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Approve(Collection collection)
        {
            var targetCollection = (from item in context.Collections
                                    where item.Id == collection.Id
                                    select item).SingleOrDefault();

            targetCollection.Status = Status.Approved;

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Reject(Collection collection)
        {
            var targetCollection = (from item in context.Collections
                                    where item.Id == collection.Id
                                    select item).SingleOrDefault();

            targetCollection.Status = Status.Rejected;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}