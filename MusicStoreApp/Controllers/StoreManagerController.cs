using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MusicStoreApp.Models;
using System.Data;

namespace MusicStoreApp.Controllers
{
    public class StoreManagerController : Controller
    {

        StoreManagerEntities storeDB = new StoreManagerEntities();

        public ActionResult Index()
        {

            var products = storeDB.Products;
            return View(products.ToList());
        }

        public ActionResult Edit(int id)
        {
            Product product = storeDB.Products.Find(id);
            if (product==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(product).State = EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult Details(int id)
        {
            Product product = storeDB.Products.Find(id);
            if (product==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

    }
}
