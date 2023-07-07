using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.GenricRepository;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentsController : Controller
    {
        private IUnitOfWork unitOfWork;
        public StudentsController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public ActionResult Index()
        {
            //var model = _bookRepository.GetAllBooks();
            var model = unitOfWork.StudentRepo.GetAll();
            return View(model);
        }
        public ActionResult AddStudent()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Student Failed";
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.StudentRepo.Insert(student);
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
            return View(student);
            //return RedirectToAction("AddBook", "Book");
        }
        public ActionResult EditStudent(int StudentId)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Edit Employee Failed";
            }
            Student student = unitOfWork.StudentRepo.GetById(StudentId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.StudentRepo.Update(student);
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
            return View(student);
        }
        public ActionResult DeleteStudent(bool? saveChangesError = false, int StudentId = 0)
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Delete Student Failed";
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Student student = unitOfWork.StudentRepo.GetById(StudentId);
            //Book book = _bookRepository.GetBookById(BookId);
            return View(student);
        }
        [HttpPost]
        public ActionResult DeleteStudent(Student student)
        {
            try
            {
                //_bookRepository.DeleteBook(book.BookId);
                //_bookRepository.Save();
                unitOfWork.StudentRepo.Delete(student.StudentId);
                unitOfWork.save();
            }
            catch (Exception ex)
            {
                TempData["Failed"] = "Delete Student Failed";
                //Log the error
                return RedirectToAction("Delete", new { id = student.StudentId, saveChangesError = true });
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
