using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            using(Model1 db = new Model1()) 
            {
                var countries = db.Countries.ToList();
                
                return View(countries);
            }
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            using (Model1 db = new Model1()) 
            {
                if(ModelState.IsValid) {
                    db.Countries.Add(country);
                    db.SaveChanges();
                } else {
                    return View(country);
                }
            }
            return Redirect("index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            using(Model1 db = new Model1()) 
            {
                //var country = db.Countries.Where(c => c.Id == id).FirstOrDefault();
                var country = db.Countries.Find(id);
                return View(country);
            }
        }

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            using(Model1 db = new Model1()) 
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}