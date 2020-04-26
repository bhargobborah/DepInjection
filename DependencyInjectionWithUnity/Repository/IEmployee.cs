using DependencyInjectionWithUnity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionWithUnity.Repository
{
    public interface IEmployee
    {
        void InsertEmployee(Employee emp);

        IEnumerable<Employee> GetEmployees();


        void UpdateEmployee(Employee emp);

        void DeleteEmployee(Employee emp);

        Employee GetEmployeeById(int? empId);
    }
}
