using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId{get;set;}

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Name is required")]
        public string EmployeeName
        {
            get;
            set;
        }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Email Id is required")]
        public string EmailId
        {
            get;
            set;
        }
    }
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Name is required")]
        public string StudentName
        {
            get;
            set;
        }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Email Id is required")]
        public string EmailId
        {
            get;
            set;
        }
    }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Name is required")]
        public string CustomerName
        {
            get;
            set;
        }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Email Id is required")]
        public string EmailId
        {
            get;
            set;
        }
    }
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("DefaultConnection") { }
        public DbSet<Employee> Employees
        {
            get;
            set;
        }
        public DbSet<Student> Students
        {
            get;
            set;
        }
        public DbSet<Customer> Customers
        {
            get;
            set;
        }
    }
}
