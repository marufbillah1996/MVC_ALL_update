using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.GenricRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IGenricRepo<Employee> EmployeeRepo { get; }
        IGenricRepo<Student> StudentRepo { get; }
        IGenricRepo<Customer> CustomerRepo { get; }
        void save();
    }
}
