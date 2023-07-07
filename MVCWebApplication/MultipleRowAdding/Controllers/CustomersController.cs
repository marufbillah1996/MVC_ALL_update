using MultipleRowAdding.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultipleRowAdding.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ProductDbContext db = new ProductDbContext();
        // GET: Customers
        public ActionResult Index(string option, string search)
        {
            if (option == "CustomerName")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.Customers.Where(x => x.CustomerName.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.Customers.Where(x => x.CustomerAddress.StartsWith(search) || search == null).ToList());
                
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        public ActionResult EditCustomer(int CustomerId)
        {
            Customer customer = db.Customers.Find(CustomerId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    db.Entry(customer).State= EntityState.Modified;
                    db.SaveChanges();
                    //_bookRepository.UpdateBook(book);
                    //_bookRepository.Save();
                    return RedirectToAction("Index", "Customers");
                }
            //}
            //catch (Exception ex)
            //{
            //    //Log the error
            //    ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            //    TempData["Failed"] = "Failed";
            //}
            return View(customer);
        }
        public ActionResult Delete(bool? saveChangesError = false, int CustomerId = 0)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Student Failed";
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Customer customer = db.Customers.Find(CustomerId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                //_bookRepository.DeleteBook(book.BookId);
                //_bookRepository.Save();
                db.Entry(customer).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["Failed"] = "Delete Student Failed";
                //Log the error
                return RedirectToAction("Delete", new { id = customer.CustomerId, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }
    }
}