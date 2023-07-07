using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.GenricRepository;
using WebApplication.Models;
using WebApplication.Repository;

namespace WebApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private IUnitOfWork unitOfWork;
        public EmployeesController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public ActionResult Index()
        {
            //var model = _bookRepository.GetAllBooks();
            var model = unitOfWork.EmployeeRepo.GetAll();
            return View(model);
        }
        public ActionResult AddEmployee()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Employee Failed";
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.EmployeeRepo.Insert(employee);
                    unitOfWork.save();
                    //_bookRepository.AddBook(book);
                    //_bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //Log the error
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                TempData["Failed"] = "Failed";
            }
            return View(employee);
            //return RedirectToAction("AddBook", "Book");
        }
        public ActionResult EditEmployee(int EmployeeId)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Edit Employee Failed";
            }
            Employee employee = unitOfWork.EmployeeRepo.GetById(EmployeeId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(employee);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.EmployeeRepo.Update(employee);
                    unitOfWork.save();
                    //_bookRepository.UpdateBook(book);
                    //_bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //Log the error
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
                TempData["Failed"] = "Failed";
            }
            return View(employee);
        }
        public ActionResult DeleteEmployee(bool? saveChangesError = false, int EmployeeId = 0)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Employee Failed";
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Employee employee = unitOfWork.EmployeeRepo.GetById(EmployeeId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(employee);
        }
        [HttpPost]
        public ActionResult DeleteEmployee(Employee employee)
        {
            try
            {
                //_bookRepository.DeleteBook(book.BookId);
                //_bookRepository.Save();
                unitOfWork.EmployeeRepo.Delete(employee.EmployeeId);
                unitOfWork.save();
            }
            catch (Exception ex)
            {
                TempData["Failed"] = "Delete Employee Failed";
                //Log the error
                return RedirectToAction("Delete", new { id = employee.EmployeeId, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }
        //private IEmployeeRepository emprepo;
        //public EmployeesController()
        //{
        //    emprepo = new EmployeeRepository(new Models.EmployeeContext());
        //}
        //public EmployeesController(IEmployeeRepository employeeRepository)
        //{
        //    emprepo = employeeRepository;
        //}
        //// GET: Employees
        //public ActionResult Index()
        //{
        //    var model = emprepo.GetAllEmployee();
        //    return View(model);
        //}
        //public ActionResult AddEmployee()
        //{
        //    if (TempData["Failed"] != null)
        //    {
        //        ViewBag.Failed = "Add Employee Failed";
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddEmployee(Employee model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int result = emprepo.AddEmployee(model);
        //        if (result > 0)
        //        {
        //            return RedirectToAction("Index", "Employees");
        //        }
        //        else
        //        {
        //            TempData["Failed"] = "Failed";
        //            return RedirectToAction("AddEmployee", "Employees");
        //        }
        //    }
        //    return View();
        //}
        //public ActionResult EditEmployee(int EmployeeId)
        //{
        //    if (TempData["Failed"] != null)
        //    {
        //        ViewBag.Failed = "Edit Employee Failed";
        //    }
        //    Employee model = emprepo.GetEmployeeById(EmployeeId);
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult EditEmployee(Employee model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        int result = emprepo.UpdateEmployee(model);
        //        if (result > 0)
        //        {
        //            return RedirectToAction("Index", "Employees");
        //        }
        //        else
        //        {

        //            return RedirectToAction("Index", "Employees");
        //        }
        //    }
        //    return View();
        //}
    }
}