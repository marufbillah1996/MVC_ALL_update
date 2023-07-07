using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.GenricRepository;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CustomersController : Controller
    {
        private IUnitOfWork unitOfWork;
        public CustomersController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public ActionResult Index()
        {
            //var model = _bookRepository.GetAllBooks();
            var model = unitOfWork.CustomerRepo.GetAll();
            return View(model);
        }
        public ActionResult AddCustomer()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Customer Failed";
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            //try
            //{
                if (ModelState.IsValid)
                {
                    unitOfWork.CustomerRepo.Insert(customer);
                    unitOfWork.save();
                    //_bookRepository.AddBook(book);
                    //_bookRepository.Save();
                    return RedirectToAction("Index");
                }
            //}
            //catch (Exception ex)
            //{
            //    //Log the error
            //    ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            //    TempData["Failed"] = "Failed";
            //}
            return View(customer);
            //return RedirectToAction("AddBook", "Book");
        }
        public ActionResult EditCustomer(int CustomerId)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Edit Customer Failed";
            }
            Customer customer = unitOfWork.CustomerRepo.GetById(CustomerId);
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
                    unitOfWork.CustomerRepo.Update(customer);
                    unitOfWork.save();
                    //_bookRepository.UpdateBook(book);
                    //_bookRepository.Save();
                    return RedirectToAction("Index");
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
        public ActionResult DeleteCustomer(bool? saveChangesError = false, int CustomerId = 0)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Customer Failed";
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Customer customer = unitOfWork.CustomerRepo.GetById(CustomerId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(customer);
        }
        [HttpPost]
        public ActionResult DeleteCustomer(Customer customer)
        {
            //try
            //{
                //_bookRepository.DeleteBook(book.BookId);
                //_bookRepository.Save();
                unitOfWork.CustomerRepo.Delete(customer.CustomerId);
                unitOfWork.save();
            //}
            //catch (Exception ex)
            //{
            //    TempData["Failed"] = "Delete Customer Failed";
            //    //Log the error
            //    return RedirectToAction("Delete", new { id = customer.CustomerId, saveChangesError = true });
            //}

            return RedirectToAction("Index");
        }
    }
}