using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.GenricRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private EmployeeContext empContext = new EmployeeContext();
        public IGenricRepo<Employee> employeeRepository;
        public IGenricRepo<Student> studentRepository;
        public IGenricRepo<Customer> customerRepository;

        public IGenricRepo<Employee> EmployeeRepo
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new GenricRepo<Employee>(empContext);
                }
                return employeeRepository;
            }
        }

        public IGenricRepo<Student> StudentRepo
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenricRepo<Student>(empContext);
                }
                return studentRepository;
            }
        }

        public IGenricRepo<Customer> CustomerRepo
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenricRepo<Customer>(empContext);
                }
                return customerRepository;
            }
        }

        public void save()
        {
            empContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    empContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}