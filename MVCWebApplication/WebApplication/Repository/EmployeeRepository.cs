using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly EmployeeContext _db;
        public EmployeeRepository(EmployeeContext db)
        {
            _db = db;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _db.Employees.ToList();
        }
        public Employee GetEmployeeById(int employeeId)
        {
            return _db.Employees.Find(employeeId);
        }
        public int AddEmployee(Employee employeeEntity)

        {
            int result = -1;

            if (employeeEntity != null)
            {
                _db.Employees.Add(employeeEntity);
                _db.SaveChanges();
                result = employeeEntity.EmployeeId;
            }
            return result;

        }
        public int UpdateEmployee(Employee employeeEntity)
        {
            int result = -1;

            if (employeeEntity != null)
            {
                _db.Entry(employeeEntity).State = EntityState.Modified;
                _db.SaveChanges();
                result = employeeEntity.EmployeeId;
            }
            return result;
        }
        public void DeleteEmployee(int employeeId)
        {
            Employee employeeEntity = _db.Employees.Find(employeeId);
            _db.Employees.Remove(employeeEntity);
            _db.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
    }
}