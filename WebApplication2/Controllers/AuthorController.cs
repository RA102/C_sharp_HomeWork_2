using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            using (Model1 db = new Model1()) {

                var authors = db.Authors.Include(c => c.Country).ToList();
                return View(authors);
            }

        }


        [HttpGet]
        public ActionResult Create()
        {
            using(Model1 db = new Model1()) 
            {
                ViewBag.CountryList = new SelectList(db.Countries.ToList(), "Id", "CountryName");
                return View();
            }

        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            using (Model1 db = new Model1()) 
            {
                if(ModelState.IsValid) {
                    db.Authors.Add(author);
                    db.SaveChanges();
                } else {

                    return View(author); 
                }

                return Redirect("index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using(Model1 db = new Model1()) 
            {
                var author = db.Authors.Find(id);
                ViewBag.CountryList = new SelectList(db.Countries.ToList(), "Id", "CountryName");
                return View(author);
            }
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            using(Model1 db = new Model1()) 
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using(Model1 db = new Model1()) 
            {
                Author author = db.Authors.Find(id);
                db.Authors.Remove(author);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}