using MultipleRowAdding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleRowAdding.Controllers
{
    public class SupplierCategoriesController : Controller
    {
        private readonly ProductDbContext db = new ProductDbContext();
        // GET: SupplierCategorys
        public ActionResult Index()
        {
            return View(db.SupplierCategorys.ToList());
        }
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(SupplierCategory sCategory)
        {
            if (ModelState.IsValid)
            {
                db.SupplierCategorys.Add(sCategory);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "SupplierCategories");
        }
    }
}