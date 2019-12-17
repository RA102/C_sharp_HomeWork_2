using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using(Model1 db = new Model1()) 
            {
                var books = db.Books.Include(a => a.Author).ToList();
               
                return View(books);
            }
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            using(Model1 db = new Model1()) 
            {
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "SurName");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            using(Model1 db = new Model1()) 
            {
                if(ModelState.IsValid) {
                    db.Books.Add(book);
                    db.SaveChanges();
                } else {

                    return View(book);

                }
            }

            return Redirect("index");
        }

        public ActionResult Delete()
        {
            return View("index");
        }
    }
}