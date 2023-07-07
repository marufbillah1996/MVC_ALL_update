using Antlr.Runtime.Misc;
using MultipleRowAdding.Models;
using MultipleRowAdding.Models.VM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleRowAdding.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext db = new ProductDbContext();
        // GET: Customers

        //public ActionResult Index(string pProductName)
        //{


        //    //var model = db.Products
        //    //    .Where(x => x.ProductName.ToLower().Contains(productName.ToLower()));
        //    var data = db.Products.Where(x=>x.ProductName.ToLower().Contains(pProductName.ToLower())).ToList();
        //    //var data = db.Products.ToList();
        //    ViewBag.result = data;
        //    return View();


        //}
        //public ActionResult Index(string option, string search)
        //{
        //    //List<Product> products = db.Products.ToList();
        //    ////pass the StudentList list object to the view.  
        //    //return View(products);
        //    if (option == "ProductPrice")
        //    {
        //        //Index action method will return a view with a student records based on what a user specify the value in textbox  
        //        return View(db.Products.Where(x => x.ProductPrice.ToString() == search || search == null).ToList());
        //    }
        //    else
        //    {
        //        return View(db.Products.Where(x => x.ProductName.StartsWith(search) || search == null).ToList());
        //    }
        //}
        public ActionResult Index(string search)
        {
            //List<Product> products = db.Products.ToList();
            ////pass the StudentList list object to the view.  
            //return View(products);
            
                return View(db.Products.Where(x => x.ProductName.StartsWith(search) || search == null).ToList());
            
        }

        //[HttpPost]
        //public JsonResult SearchProduct(string productName)
        //{
        //    if (!string.IsNullOrEmpty(productName))
        //    {
        //        //var products = db.Products.Where(x => x.ProductName == productName).ToList();
        //        ////var products = from c in db.Products
        //        ////               where c.ProductName.Contains(productName)
        //        ////               select c;
        //        //return Json(products,JsonRequestBehavior.AllowGet);

        //        var products2 = db.Products.ToList();
        //        //var products = from c in db.Products
        //        //               where c.ProductName.Contains(productName)
        //        //               select c;
        //        return Json(products2, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        var products22 = db.Products.ToList();
        //        //var products = from c in db.Products
        //        //               where c.ProductName.Contains(productName)
        //        //               select c;
        //        return Json(products22, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        public ActionResult EditProduct(int ProductId)
        {
            Product product = db.Products.Find(ProductId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            //try
            //{
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                //_bookRepository.UpdateBook(book);
                //_bookRepository.Save();
                return RedirectToAction("Index", "Products");
            }
            //}
            //catch (Exception ex)
            //{
            //    //Log the error
            //    ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            //    TempData["Failed"] = "Failed";
            //}
            return View(product);
        }
        public ActionResult Delete(bool? saveChangesError = false, int ProductId = 0)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Student Failed";
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Product product = db.Products.Find(ProductId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                //_bookRepository.DeleteBook(book.BookId);
                //_bookRepository.Save();
                db.Entry(product).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["Failed"] = "Delete Student Failed";
                //Log the error
                return RedirectToAction("Delete", new { id = product.ProductId, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }
    }
}