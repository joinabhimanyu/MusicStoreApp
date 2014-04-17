using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using MusicStoreApp.Models;
using MusicStoreApp.Classes;

namespace MusicStoreApp.Controllers
{
    public class SocialController : Controller
    {

        StoreManagerEntities storeDB = new StoreManagerEntities();

        public ActionResult Index()
        {
            string entry = "abhimanyu;chakraborty";
            int len = entry.Length;
            int index = entry.LastIndexOf(";");
            string first = entry.Substring(0, index);
            string second = entry.Substring(index + 1);

            return View();
        }

        public JsonResult GetData()
        {
            return Json(storeDB.Products.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            if (ModelState.IsValid)
            {
                storeDB.Entry(product).State = EntityState.Modified;
                storeDB.SaveChanges();
                return Json(product.ProductID);
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                storeDB.Products.Add(product);
                storeDB.SaveChanges();
                return Json(product.ProductID);
            }
            return View(product);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Product product = storeDB.Products.Find(id);
                storeDB.Products.Remove(product);
                storeDB.SaveChanges();
                return Json(storeDB.Products.ToList());
            }
            return Json(storeDB.Products.ToList());
        }

        //public JsonResult Link1Content()
        //{
        //    object model = null;
        //    var result = RenderHelper.RenderPartialViewtoString(this, "Link1Content", model);
        //    return Json(result,JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Link1Content()
        {
            Session["name"] = "abhimanyu";
            return View();
        }

        public ActionResult Link2Content()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string uname,string password)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Register(string frmUname, string frmFName, string frmLName, string frmPass, string frmCPass, string rdbSex, string frmEmail)
        {
            return RedirectToAction("Index");
        }
            
    }
}
