using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStoreApp.Models;

namespace MusicStoreApp.Controllers
{
    public class MusicStoreController : Controller
    {
        

        private MusicStoreDBContext db = new MusicStoreDBContext();

        //
        // GET: /StoreManager/

        public ActionResult Index()
        {
            var albums = db.Albums.Include(a => a.Genre).Include(a => a.Artist);
            return View(albums.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //public ActionResult Search()
        //{
        //    if (Request.IsAjaxRequest())
        //    {
        //        return PartialView();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
          
        //}

        public ActionResult Search()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.Genres = new SelectList(db.Genres,"GenreId","Name");
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    
        public ActionResult SearchResult(string Genres, string artist, string title, string price)
        {
            //var album1=null;
            List<Album> album1;
            List<Album> album2;
            List<Album> album3;
            List<Album> album4;
            if (Request.IsAjaxRequest())
            {
                if (Genres != "")
                {
                    int genre = Convert.ToInt32(Genres);
                    album1 = db.Albums.Where(a => a.Genre.GenreId.Equals(genre)).ToList();

                    if (artist!="")
                    {
                        album2 = album1.Where(a => a.Artist.Name.Equals(artist)).ToList();

                        if (title!="")
                        {

                            album3 = album2.Where(a => a.Title.Equals(title)).ToList();

                            if (price!="")
                            {
                                decimal p = Convert.ToDecimal(price);
                                album4 = album3.Where(a => a.Price.Equals(p)).ToList();

                                return PartialView(album4);

                            }
                            else
                            {
                                return PartialView(album3);
                            }

                        }
                        else
                        {
                            return PartialView(album2);
                        }
                    }
                    else
                    {
                        return PartialView(album1);
                    }
                }

            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        public JsonResult SearchName(string id)
        {
            if (Request.IsAjaxRequest())
            {
                var result = "You have entered : " + id;
                return Json(result,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { data="error from action"});
            }
            
        }

    }
}