using BibParts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibParts.Controllers
{
    public class PartsController : Controller
    {

        BibPartDb _db = new BibPartDb(); 
        // GET: Parts
        public ActionResult Index()
        {
            return GetPartsListView();
        }

        // GET: Parts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddInstance(int id)
        {
            if (_db.Parts.Any(p => p.Id == id))
            {
                _db.PartInstances.Add(new PartInstance { PartId = id, InUse = false });
                _db.SaveChanges();
            }
            return GetPartsListView();
        }

        [HttpGet]
        public ActionResult RemoveInstance(int id)
        {
                var entityToRemove = _db.PartInstances.FirstOrDefault(pi => pi.PartId == id && pi.InUse == false);
                if (entityToRemove != null)
                {
                    _db.PartInstances.Remove(entityToRemove);
                    _db.SaveChanges();
                }

            return GetPartsListView();
        }

        private ActionResult GetPartsListView()
        {
            var model = from pi in _db.PartInstances
                        group pi by pi.PartId into partInstances
                        select new PartListViewItem
                        {
                            PartItem = _db.Parts.Where(p => p.Id == partInstances.Key).FirstOrDefault(),
                            CategoryName = _db.Categories.Where(c => c.Id == (_db.Parts.Where(p => p.Id == partInstances.Key)
                                                        .FirstOrDefault().CategoryId))
                                                        .FirstOrDefault().Name,
                            NumberInUse = partInstances.Where(pi => pi.InUse).Count(),
                            TotalNumber = partInstances.Count()
                        };

            if (Request.IsAjaxRequest())
            {
                return PartialView("PartListView", model);
            }

            return View(model);
        }
    }
}
