using MultipleRowAdding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleRowAdding.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ProductDbContext db = new ProductDbContext();
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.supplierCategory = db.SupplierCategorys.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
            return RedirectToAction("Index", "Suppliers");
        }
    }
}