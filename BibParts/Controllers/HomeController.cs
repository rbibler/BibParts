using BibParts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibParts.Controllers
{
    public class HomeController : Controller
    {
        BibPartDb _db = new BibPartDb();

        public ActionResult Index()
        {
            var model = from c in _db.Categories
                        orderby c.Name
                        join p in _db.Parts on c.Id equals p.CategoryId
                        group c by p.CategoryId into cs

                        select new CategoryListViewItem { CategoryId = (int) cs.Key, CategoryName = cs.ToList().FirstOrDefault().Name, PartsCount = cs.ToList().Count() };

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}